using Microsoft.Reporting.WinForms;
using REPORTES.DTOs;
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
    public partial class FrmTotalPrestado : Form
    {
        public FrmTotalPrestado()
        {
            InitializeComponent();
        }

        private void FrmTotalPrestado_Load(object sender, EventArgs e)
        {
            var service = new ReporteService();

            var resumen = service.ObtenerResumenFinanciero();

            reportViewer1.Reset();

            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteFinanciero.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("ResumenFinanciero", new List<ReporteFinancieroDto> { resumen })
            );

            reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? prestamoId = null;
            if (!string.IsNullOrWhiteSpace(txtPrestamo.Text))
            {
                if (!int.TryParse(txtPrestamo.Text, out int tmpId))
                {
                    MessageBox.Show("Ingrese un ID válido");
                    return;
                }
                prestamoId = tmpId;
            }

            var service = new ReporteService();
            var resumen = service.ObtenerResumenFinanciero(prestamoId);

            if (resumen == null)
            {
                MessageBox.Show("No se encontró información financiera para este cliente");
                return;
            }

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteFinanciero.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("ResumenFinanciero", new List<ReporteFinancieroDto> { resumen })
            );
            reportViewer1.RefreshReport();
        }
    }
}
