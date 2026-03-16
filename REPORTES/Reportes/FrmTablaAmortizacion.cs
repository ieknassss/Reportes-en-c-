using Microsoft.Reporting.WinForms;
using REPORTES.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPORTES.Reportes
{
    public partial class FrmTablaAmortizacion : Form
    {
        public FrmTablaAmortizacion()
        {
            InitializeComponent();
        }

        private void FrmTablaAmortizacion_Load(object sender, EventArgs e)
        {
            var service = new ReporteService();

            var datos = service.ObtenerTablaAmortizacion(10000, 12);

            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteAmortizacion.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Amortizacion", datos)
            );

            reportViewer1.RefreshReport();
        }

    }
}
