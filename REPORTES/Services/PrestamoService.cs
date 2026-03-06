using System;
using System.Linq;
using REPORTES.Calculations;

namespace REPORTES.Services
{
    public class PrestamoService
    {
        private const decimal FondoBase = 10000000m;

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
                decimal interes = LoanCalculator.CalcularInteresSimple(monto, tasa, meses);
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

        public int ObtenerMesesPagados(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                return db.Pagos.Count(p => p.PrestamoId == prestamoId);
            }
        }

        public int ObtenerMesesRestantes(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);

                if (prestamo == null)
                    throw new Exception("Préstamo no encontrado.");

                int pagados = db.Pagos.Count(p => p.PrestamoId == prestamoId);
                int restantes = prestamo.Meses - pagados;

                if (restantes <= 0)
                    restantes = 1;

                return restantes;
            }
        }

        public decimal ObtenerInteresesAcumulados(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                decimal totalIntereses = db.Pagos
                    .Where(p => p.PrestamoId == prestamoId && p.InteresPagado.HasValue)
                    .Select(p => p.InteresPagado.Value)
                    .DefaultIfEmpty(0m)
                    .Sum();

                return totalIntereses;
            }
        }

        // Devuelve el detalle del pago sin guardarlo todavía
        public LoanCalculator.PagoCalculado ObtenerDetallePago(int prestamoId, decimal abonoExtra = 0m)
        {
            decimal montoAnterior = ObtenerMontoActual(prestamoId);
            int mesesRestantes = ObtenerMesesRestantes(prestamoId);
            decimal interesesAcumulados = ObtenerInteresesAcumulados(prestamoId);

            return LoanCalculator.CalcularPagoDelMes(
                montoAnterior,
                mesesRestantes,
                interesesAcumulados,
                abonoExtra
            );
        }

        public void RegistrarPago(int prestamoId, decimal abonoExtra, bool pagoRealizado, int mesNumero)
        {
            using (var db = DbContextFactory.Create())
            {
                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);

                if (prestamo == null)
                    throw new Exception("Préstamo no encontrado.");

                var detallePago = ObtenerDetallePago(prestamoId, abonoExtra);

                if (!pagoRealizado)
                {
                    decimal montoMora = LoanCalculator.CalcularMora(detallePago.Cuota);

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

                Pagos nuevoPago = new Pagos
                {
                    PrestamoId = prestamoId,
                    MontoAnterior = detallePago.MontoAnterior,
                    InteresPagado = detallePago.InteresAPagar,
                    MontoAbonado = detallePago.CapitalPagado,
                    NuevoMonto = detallePago.NuevoMontoAdeudado,
                    FechaPago = DateTime.Now
                };

                db.Pagos.Add(nuevoPago);
                db.SaveChanges();
            }
        }
    }
}