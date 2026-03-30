using System.Collections.Generic;
using System.Linq;
using REPORTES.DTOs;
using REPORTES.Calculations;

namespace REPORTES.Services
{
    public class ReporteService
    {
        // ======================================
        // Tabla de amortización
        // ======================================
        public List<ReporteAmortizacionDto> ObtenerTablaAmortizacion(decimal monto, int meses)
        {
            return LoanCalculator.GenerarTablaAmortizacion(monto, meses)
                .Select(x => new ReporteAmortizacionDto
                {
                    Mes = x.Mes,
                    Cuota = x.Cuota,
                    Interes = x.Interes,
                    Capital = x.Capital,
                    Saldo = x.Saldo
                }).ToList();
        }

        // ======================================
        // Detalle de un cliente
        // ======================================
        public ReporteClienteDto ObtenerDetalleCliente(int clienteId)
        {
            using (var db = DbContextFactory.Create())
            {
                return (from c in db.Clientes
                        join p in db.Prestamos on c.Id equals p.ClienteId
                        where c.Id == clienteId
                        select new ReporteClienteDto
                        {
                            ClienteId = c.Id,
                            NombreCompleto = c.NombreCompleto,
                            Correo = c.Correo,
                            Telefono = c.Telefono,
                            Direccion = c.Direccion,
                            Garantia = c.Garantia,
                            Sueldo = c.Sueldo,
                            EsMoroso = c.EsMoroso ?? false,
                            MontoPrestado = p.Monto,
                            InteresGenerado = p.InteresGenerado ?? 0m,
                            MontoTotal = p.MontoTotal ?? 0m,
                            Meses = p.Meses
                        }).FirstOrDefault();
            }
        }

        // ======================================
        // Resumen financiero (con filtro opcional)
        // ======================================
        public ReporteFinancieroDto ObtenerResumenFinanciero(int? clienteId = null)
        {
            using (var db = DbContextFactory.Create())
            {
                var prestamos = db.Prestamos.AsQueryable();
                if (clienteId.HasValue)
                    prestamos = prestamos.Where(p => p.ClienteId == clienteId.Value);

                return new ReporteFinancieroDto
                {
                    TotalPrestado = prestamos.Select(p => p.Monto).DefaultIfEmpty(0m).Sum(),
                    TotalGanancia = prestamos.Where(p => p.InteresGenerado != null)
                                             .Select(p => p.InteresGenerado.Value)
                                             .DefaultIfEmpty(0m)
                                             .Sum()
                };
            }
        }

        // ======================================
        // Moras acumuladas (con filtro opcional)
        // ======================================
        public List<ReporteMoraDto> ObtenerMorasPorCliente(int? clienteId = null)
        {
            using (var db = DbContextFactory.Create())
            {
                var query = from c in db.Clientes
                            join p in db.Prestamos on c.Id equals p.ClienteId
                            join m in db.Moras on p.Id equals m.PrestamoId
                            select new ReporteMoraDto
                            {
                                ClienteId = c.Id,
                                Cliente = c.NombreCompleto,
                                CantidadMoras = m.Cantidad ?? 0
                            };

                if (clienteId.HasValue)
                    query = query.Where(q => q.ClienteId == clienteId.Value);

                return query.ToList();
            }
        }

        // ======================================
        // Clientes morosos (con filtro opcional)
        // ======================================
        public List<ReporteMorosoDto> ObtenerClientesMorosos(int? clienteId = null)
        {
            using (var db = DbContextFactory.Create())
            {
                var query = db.Clientes.Where(c => c.EsMoroso == true);

                if (clienteId.HasValue)
                    query = query.Where(c => c.Id == clienteId.Value);

                return query.Select(c => new ReporteMorosoDto
                {
                    ClienteId = c.Id,
                    NombreCompleto = c.NombreCompleto,
                    Correo = c.Correo,
                    Telefono = c.Telefono
                }).ToList();
            }
        }
    }
}