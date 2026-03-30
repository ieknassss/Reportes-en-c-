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
    public partial class FrmMorasAcumuladas : Form
    {
        public FrmMorasAcumuladas()
        {
            InitializeComponent();
        }

        private void FrmMorasAcumuladas_Load(object sender, EventArgs e)
        {
            var service = new ReporteService();

            var datos = service.ObtenerMorasPorCliente();

            reportViewer1.Reset();

            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteMoras.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Moras", datos)
            );

            reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPrestamo.Text, out int prestamoId))
            {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var service = new ReporteService();
            var datos = service.ObtenerMorasPorCliente(prestamoId);

            if (datos == null || !datos.Any())
            {
                MessageBox.Show("No se encontraron moras para este cliente");
                return;
            }

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteMoras.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Moras", datos)
            );
            reportViewer1.RefreshReport();
        }
    }
}
