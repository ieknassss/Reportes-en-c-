using System;
using System.Collections.Generic;

namespace REPORTES.Calculations
{
    public static class LoanCalculator
    {
        // ==============================
        // TASAS SEGÚN REGLA DEL NEGOCIO
        // ==============================
        public static decimal ObtenerTasaAnual(int meses)
        {
            if (meses <= 12)
                return 0.1325m;

            if (meses <= 24)
                return 0.15m;

            return 0.30m;
        }

        // ==============================
        // TASA MENSUAL (TEM)
        // ==============================
        public static decimal CalcularTasaMensual(decimal tasaAnual)
        {
            return Math.Round((decimal)Math.Pow((double)(1 + tasaAnual), 1.0 / 12.0) - 1, 8);
        }

        // ==============================
        // INTERÉS SIMPLE
        // ==============================
        public static decimal CalcularInteresSimple(decimal monto, decimal tasaAnual, int meses)
        {
            decimal tiempoEnAnios = meses / 12m;
            return Math.Round(monto * tasaAnual * tiempoEnAnios, 2);
        }

        public static decimal CalcularMontoTotal(decimal monto, decimal interes)
        {
            return Math.Round(monto + interes, 2);
        }

        // ==============================
        // CUOTA MENSUAL (SISTEMA FRANCÉS)
        // ==============================
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

        // ==============================
        // MORA (10%)
        // ==============================
        public static decimal CalcularMora(decimal cuotaMensual)
        {
            return Math.Round(cuotaMensual * 0.10m, 2);
        }

        // ==============================
        // MODELO DE AMORTIZACIÓN
        // ==============================
        public class AmortizacionItem
        {
            public int Mes { get; set; }
            public decimal SaldoAnterior { get; set; }
            public decimal Cuota { get; set; }
            public decimal Interes { get; set; }
            public decimal Capital { get; set; }
            public decimal Saldo { get; set; }
            public int MesesRestantes { get; set; }
            public decimal TotalInteresesAcumulados { get; set; }
            public decimal TasaMensual { get; set; }
            public decimal TasaAnual { get; set; }
        }

        // ==============================
        // GENERAR TABLA DE AMORTIZACIÓN
        // (POR PRÉSTAMO)
        // ==============================
        public static List<AmortizacionItem> GenerarTablaAmortizacion(decimal monto, int meses, decimal tasa)
        {
            var tabla = new List<AmortizacionItem>();

            decimal saldo = monto;
            decimal interesMensual = tasa / 12;

            decimal cuota = monto * (interesMensual * (decimal)Math.Pow(1 + (double)interesMensual, meses)) /
                            ((decimal)Math.Pow(1 + (double)interesMensual, meses) - 1);

            for (int i = 1; i <= meses; i++)
            {
                decimal interes = saldo * interesMensual;
                decimal capital = cuota - interes;
                saldo -= capital;

                tabla.Add(new AmortizacionItem
                {
                    Mes = i,
                    Cuota = cuota,
                    Interes = interes,
                    Capital = capital,
                    Saldo = saldo < 0 ? 0 : saldo
                });
            }

            return tabla;
        }

        // ==============================
        // CÁLCULO DE PAGO DEL MES
        // ==============================
        public class PagoCalculado
        {
            public decimal MontoAnterior { get; set; }
            public decimal Cuota { get; set; }
            public decimal InteresAPagar { get; set; }
            public decimal CapitalPagado { get; set; }
            public decimal NuevoMontoAdeudado { get; set; }
            public int MesesRestantes { get; set; }
            public decimal TotalInteresesAcumulados { get; set; }
            public decimal TasaMensual { get; set; }
            public decimal TasaAnual { get; set; }
        }

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

            decimal interes = Math.Round(montoAnterior * tasaMensual, 2);
            decimal capital = Math.Round(cuota - interes, 2);

            if (abonoExtra > 0)
                capital += abonoExtra;

            decimal nuevoMonto = Math.Round(montoAnterior - capital, 2);

            return new PagoCalculado
            {
                MontoAnterior = montoAnterior,
                Cuota = cuota,
                InteresAPagar = interes,
                CapitalPagado = capital,
                NuevoMontoAdeudado = nuevoMonto < 0 ? 0 : nuevoMonto,
                MesesRestantes = Math.Max(mesesRestantes - 1, 0),
                TotalInteresesAcumulados = Math.Round(interesesAcumuladosPrevios + interes, 2),
                TasaMensual = tasaMensual,
                TasaAnual = tasaAnual
            };
        }

        internal static IEnumerable<AmortizacionItem> GenerarTablaAmortizacion(decimal monto, int meses)
        {
            throw new NotImplementedException();
        }
    }
}