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
    public partial class FrmInformacionCliente : Form
    {
        public FrmInformacionCliente()
        {
            InitializeComponent();
        }

        private void FrmInformacionCliente_Load(object sender, EventArgs e)
        {
            var service = new ReporteService();

            var cliente = service.ObtenerDetalleCliente(1);

            reportViewer1.Reset();

            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Clientes", new List<ReporteClienteDto> { cliente })
            );

            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

           private void button1_Click(object sender, EventArgs e)
        {
            // Validar que el usuario ingresó un ID
            if (!int.TryParse(txtPrestamo.Text, out int clienteId))
            {
                MessageBox.Show("Ingrese un ID de cliente válido");
                return;
            }

            var service = new ReporteService();

            // Obtener el detalle del cliente por ID
            var cliente = service.ObtenerDetalleCliente(clienteId);

            if (cliente == null)
            {
                MessageBox.Show("No se encontró el cliente con ese ID");
                return;
            }

            // Resetear y cargar el ReportViewer
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath = "Reportes/ReporteCliente.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Clientes", new List<ReporteClienteDto> { cliente })
            );

            reportViewer1.RefreshReport();
        }
    }
}

