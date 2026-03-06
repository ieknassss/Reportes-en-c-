using System;
using System.Collections.Generic;

namespace REPORTES.Calculations
{
    public static class LoanCalculator
    {
        public static decimal ObtenerTasaAnual(int meses)
        {
            if (meses <= 3) return 0.10m;
            if (meses <= 6) return 0.08m;
            if (meses <= 12) return 0.07m;

            return 0.05m;
        }

        public static decimal CalcularInteresSimple(decimal monto, decimal tasa)
        {
            return Math.Round(monto * tasa, 2);
        }

        public static decimal CalcularMontoTotal(decimal monto, decimal interes)
        {
            return monto + interes;
        }

        public static decimal CalcularCuotaMensual(decimal principal, decimal tasaAnual, int meses)
        {
            decimal tasaMensual = tasaAnual / 12;

            decimal potencia = (decimal)Math.Pow((double)(1 + tasaMensual), meses);

            decimal cuota = principal * (tasaMensual * potencia) / (potencia - 1);

            return Math.Round(cuota, 2);
        }

        public static decimal CalcularMora(decimal cuota)
        {
            return cuota * 0.10m;
        }

        public class AmortizacionItem
        {
            public int Mes { get; set; }
            public decimal Cuota { get; set; }
            public decimal Interes { get; set; }
            public decimal Capital { get; set; }
            public decimal Saldo { get; set; }
        }

        public static List<AmortizacionItem> GenerarTablaAmortizacion(decimal monto, int meses)
        {
            decimal tasa = ObtenerTasaAnual(meses);
            decimal saldo = monto;

            decimal cuota = CalcularCuotaMensual(monto, tasa, meses);

            decimal tasaMensual = tasa / 12;

            List<AmortizacionItem> tabla = new List<AmortizacionItem>();

            for (int mes = 1; mes <= meses; mes++)
            {
                decimal interes = saldo * tasaMensual;
                decimal capital = cuota - interes;

                saldo -= capital;

                if (saldo < 0)
                    saldo = 0;

                tabla.Add(new AmortizacionItem
                {
                    Mes = mes,
                    Cuota = cuota,
                    Interes = interes,
                    Capital = capital,
                    Saldo = saldo
                });
            }

            return tabla;
        }
    }
}