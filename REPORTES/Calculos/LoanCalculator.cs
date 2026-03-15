using System;
using System.Collections.Generic;

namespace REPORTES.Calculations
{
    public static class LoanCalculator
    {
        // Tasas nuevas del profesor
        // Hasta 12 meses = 13.25%
        // Más de 12 y hasta 24 meses = 15%
        // Más de 24 meses = 30%
        public static decimal ObtenerTasaAnual(int meses)
        {
            if (meses <= 12)
                return 0.1325m;

            if (meses <= 24)
                return 0.15m;

            return 0.30m;
        }

        // TEM = (1 + TEA)^(1/12) - 1
        public static decimal CalcularTasaMensual(decimal tasaAnual)
        {
            decimal tasaMensual = (decimal)Math.Pow((double)(1 + tasaAnual), 1.0 / 12.0) - 1;
            return Math.Round(tasaMensual, 6);
        }

        // Interés simple: I = P * r * t
        // t en años
        public static decimal CalcularInteresSimple(decimal monto, decimal tasaAnual, int meses)
        {
            decimal tiempoEnAnios = meses / 12m;
            decimal interes = monto * tasaAnual * tiempoEnAnios;
            return Math.Round(interes, 2);
        }

        public static decimal CalcularMontoTotal(decimal monto, decimal interes)
        {
            return Math.Round(monto + interes, 2);
        }

        // Sistema Francés / cuota fija
        public static decimal CalcularCuotaMensual(decimal monto, decimal tasaAnual, int meses)
        {
            if (meses <= 0)
                throw new ArgumentException("El plazo debe ser mayor que cero.");

            decimal tasaMensual = CalcularTasaMensual(tasaAnual);

            if (tasaMensual == 0)
                return Math.Round(monto / meses, 2);

            decimal potencia = (decimal)Math.Pow((double)(1 + tasaMensual), meses);
            decimal cuota = monto * (tasaMensual * potencia) / (potencia - 1);

            return Math.Round(cuota, 2);
        }

        public static decimal CalcularMora(decimal cuotaMensual)
        {
            return Math.Round(cuotaMensual * 0.10m, 2);
        }

        public class AmortizacionItem
        {
            public int Mes { get; set; }
            public decimal SaldoAnterior { get; set; }
            public decimal TasaMensual { get; set; }
            public decimal Cuota { get; set; }
            public decimal Interes { get; set; }
            public decimal Capital { get; set; }
            public decimal Saldo { get; set; }
            public int MesesRestantes { get; set; }
            public decimal TotalInteresesAcumulados { get; set; }
            public decimal TasaAnual { get; set; }
        }

        public class PagoCalculado
        {
            public decimal MontoAnterior { get; set; }
            public decimal TasaAnual { get; set; }
            public decimal TasaMensual { get; set; }
            public decimal Cuota { get; set; }
            public decimal InteresAPagar { get; set; }
            public decimal CapitalPagado { get; set; }
            public decimal NuevoMontoAdeudado { get; set; }
            public int MesesRestantes { get; set; }
            public decimal TotalInteresesAcumulados { get; set; }
        }

        public static List<AmortizacionItem> GenerarTablaAmortizacion(decimal monto, int meses)
        {
            decimal tasaAnual = ObtenerTasaAnual(meses);
            decimal tasaMensual = CalcularTasaMensual(tasaAnual);
            decimal cuota = CalcularCuotaMensual(monto, tasaAnual, meses);

            List<AmortizacionItem> tabla = new List<AmortizacionItem>();
            decimal saldo = monto;
            decimal interesesAcumulados = 0m;

            for (int mes = 1; mes <= meses; mes++)
            {
                decimal saldoAnterior = saldo;
                decimal interes = Math.Round(saldoAnterior * tasaMensual, 2);
                decimal capital = Math.Round(cuota - interes, 2);
                decimal nuevoSaldo = Math.Round(saldoAnterior - capital, 2);

                if (nuevoSaldo < 0)
                    nuevoSaldo = 0;

                if (mes == meses && nuevoSaldo != 0)
                {
                    capital += nuevoSaldo;
                    cuota = Math.Round(interes + capital, 2);
                    nuevoSaldo = 0;
                }

                interesesAcumulados += interes;

                tabla.Add(new AmortizacionItem
                {
                    Mes = mes,
                    SaldoAnterior = saldoAnterior,
                    TasaMensual = tasaMensual,
                    Cuota = cuota,
                    Interes = interes,
                    Capital = capital,
                    Saldo = nuevoSaldo,
                    MesesRestantes = meses - mes,
                    TotalInteresesAcumulados = Math.Round(interesesAcumulados, 2),
                    TasaAnual = tasaAnual
                });

                saldo = nuevoSaldo;
            }

            return tabla;
        }

        // Calcula el detalle del pago actual
        // Esto sirve para el formulario de pagos y el re-cálculo con abono
        public static PagoCalculado CalcularPagoDelMes(
            decimal montoAnterior,
            int mesesRestantes,
            decimal interesesAcumuladosPrevios,
            decimal abonoExtra)
        {
            if (mesesRestantes <= 0)
                mesesRestantes = 1;

            decimal tasaAnual = ObtenerTasaAnual(mesesRestantes);
            decimal tasaMensual = CalcularTasaMensual(tasaAnual);
            decimal cuota = CalcularCuotaMensual(montoAnterior, tasaAnual, mesesRestantes);

            decimal interesDelMes = Math.Round(montoAnterior * tasaMensual, 2);
            decimal capitalPagado = Math.Round(cuota - interesDelMes, 2);

            if (abonoExtra > 0)
                capitalPagado += abonoExtra;

            decimal nuevoMonto = Math.Round(montoAnterior - capitalPagado, 2);

            if (nuevoMonto < 0)
                nuevoMonto = 0;

            return new PagoCalculado
            {
                MontoAnterior = montoAnterior,
                TasaAnual = tasaAnual,
                TasaMensual = tasaMensual,
                Cuota = cuota,
                InteresAPagar = interesDelMes,
                CapitalPagado = capitalPagado,
                NuevoMontoAdeudado = nuevoMonto,
                MesesRestantes = Math.Max(mesesRestantes - 1, 0),
                TotalInteresesAcumulados = Math.Round(interesesAcumuladosPrevios + interesDelMes, 2)
            };
        }

        // Saldo pendiente
        public static decimal CalcularSaldoPendiente(decimal valorActual, decimal tasaAnual, decimal cuota, int periodo)
        {
            decimal tasaMensual = CalcularTasaMensual(tasaAnual);

            if (periodo <= 0)
                return valorActual;

            decimal potencia = (decimal)Math.Pow((double)(1 + tasaMensual), periodo - 1);

            decimal saldo = valorActual * potencia
                            - cuota * ((potencia - 1) / tasaMensual);

            if (saldo < 0)
                saldo = 0;

            return Math.Round(saldo, 2);
        }
    }
}