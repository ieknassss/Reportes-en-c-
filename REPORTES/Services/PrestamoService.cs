using System;
using System.Linq;
using REPORTES.Calculations;

namespace REPORTES.Services
{
    public class PrestamoService
    {
        private const decimal FondoBase = 5000000m;

        public decimal CalcularFondoActual()
        {
            using (var db = DbContextFactory.Create())
            {
                decimal totalPrestado = db.Prestamos
                    .Select(p => p.Monto)
                    .DefaultIfEmpty(0m)
                    .Sum();

                return FondoBase - totalPrestado;
            }
        }

        public void ValidarSolicitudPrestamo(Clientes cliente, decimal monto, int meses)
        {
            if (cliente == null)
                throw new Exception("El cliente no existe.");

            if (monto <= 0)
                throw new Exception("El monto debe ser mayor que cero.");

            if (meses <= 0)
                throw new Exception("El plazo debe ser mayor que cero.");

            if (string.IsNullOrWhiteSpace(cliente.Garantia))
                throw new Exception("No se puede otorgar un préstamo sin garantía.");

            if (cliente.Sueldo <= 0)
                throw new Exception("El cliente no tiene un sueldo válido registrado.");

            if (monto > cliente.Sueldo * 4)
                throw new Exception("No se puede prestar más de 4 veces el sueldo del cliente.");

            decimal fondoActual = CalcularFondoActual();
            if (monto > fondoActual)
                throw new Exception("La entidad no tiene fondo suficiente para otorgar este préstamo.");
        }

        public Prestamos CrearPrestamo(int clienteId, decimal monto, int meses)
        {
            using (var db = DbContextFactory.Create())
            {
                var cliente = db.Clientes.FirstOrDefault(c => c.Id == clienteId);

                ValidarSolicitudPrestamo(cliente, monto, meses);

                decimal tasa = LoanCalculator.ObtenerTasaAnual(meses);
                decimal interes = LoanCalculator.CalcularInteresSimple(monto, tasa);
                decimal montoTotal = LoanCalculator.CalcularMontoTotal(monto, interes);

                Prestamos nuevoPrestamo = new Prestamos
                {
                    ClienteId = clienteId,
                    Monto = monto,
                    Meses = meses,
                    InteresGenerado = interes,
                    MontoTotal = montoTotal,
                    FechaPrestamo = DateTime.Now
                };

                db.Prestamos.Add(nuevoPrestamo);
                db.SaveChanges();

                return nuevoPrestamo;
            }
        }

        public decimal ObtenerMontoActual(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                var ultimoPago = db.Pagos
                    .Where(p => p.PrestamoId == prestamoId && p.NuevoMonto.HasValue)
                    .OrderByDescending(p => p.FechaPago)
                    .FirstOrDefault();

                if (ultimoPago != null)
                    return ultimoPago.NuevoMonto.Value;

                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);

                if (prestamo == null)
                    throw new Exception("Préstamo no encontrado.");

                return prestamo.MontoTotal ?? 0m;
            }
        }

        public void RegistrarPago(int prestamoId, decimal montoAbonado, bool pagoRealizado, int mesNumero)
        {
            using (var db = DbContextFactory.Create())
            {
                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);

                if (prestamo == null)
                    throw new Exception("Préstamo no encontrado.");

                decimal montoAnterior = ObtenerMontoActual(prestamoId);

                int meses = prestamo.Meses;
                decimal tasaAnual = LoanCalculator.ObtenerTasaAnual(meses);
                decimal cuota = LoanCalculator.CalcularCuotaMensual(montoAnterior, tasaAnual, meses);

                if (!pagoRealizado)
                {
                    var moraExistente = db.Moras.FirstOrDefault(m => m.PrestamoId == prestamoId);

                    if (moraExistente == null)
                    {
                        Moras nuevaMora = new Moras
                        {
                            PrestamoId = prestamoId,
                            Cantidad = 1
                        };
                        db.Moras.Add(nuevaMora);
                    }
                    else
                    {
                        moraExistente.Cantidad = (moraExistente.Cantidad ?? 0) + 1;
                    }

                    db.SaveChanges();

                    var moraActualizada = db.Moras.FirstOrDefault(m => m.PrestamoId == prestamoId);
                    if (moraActualizada != null && (moraActualizada.Cantidad ?? 0) >= 3)
                    {
                        var cliente = db.Clientes.FirstOrDefault(c => c.Id == prestamo.ClienteId);
                        if (cliente != null)
                        {
                            cliente.EsMoroso = true;
                            db.SaveChanges();
                        }
                    }

                    return;
                }

                decimal interesPagado = Math.Round(montoAnterior * (tasaAnual / 12m), 2);
                decimal nuevoMonto = Math.Round(montoAnterior - montoAbonado, 2);

                if (nuevoMonto < 0)
                    nuevoMonto = 0;

                Pagos nuevoPago = new Pagos
                {
                    PrestamoId = prestamoId,
                    MontoAnterior = montoAnterior,
                    InteresPagado = interesPagado,
                    MontoAbonado = montoAbonado,
                    NuevoMonto = nuevoMonto,
                    FechaPago = DateTime.Now
                };

                db.Pagos.Add(nuevoPago);
                db.SaveChanges();
            }
        }
    }
}