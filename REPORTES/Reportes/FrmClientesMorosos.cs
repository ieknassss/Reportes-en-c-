using Microsoft.Reporting.WinForms;
using REPORTES.DTOs;
using REPORTES.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Reportes
{
    public partial class FrmClientesMorosos : Form
    {
        public FrmClientesMorosos()
        {
            InitializeComponent();
        }

        private void FrmClientesMorosos_Load(object sender, EventArgs e)
        {
            // Mostrar todos los clientes morosos por defecto
            var service = new ReporteService();
            var datos = service.ObtenerClientesMorosos(); // trae todos si no hay ID

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteMorosos.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Morosos", datos)
            );
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            // vacío, solo evita error del diseñador
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar el ID ingresado en txtPrestamo
            if (!int.TryParse(txtPrestamo.Text, out int clienteId))
            {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var service = new ReporteService();
            var datos = service.ObtenerClientesMorosos(clienteId); // filtra por ID

            if (datos == null || !datos.Any())
            {
                MessageBox.Show("No se encontraron clientes morosos con este ID");
                return;
            }

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteMorosos.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Morosos", datos)
            );
            reportViewer1.RefreshReport();
        }
    }
}