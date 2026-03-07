using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmGestionPagos : Form
    {
        public FrmGestionPagos()
        {
            InitializeComponent();
        }

        private void btnCalcularPago_Click(object sender, EventArgs e)
        {
            double montoAnterior = Convert.ToDouble(txtMontoAnterior.Text);
            double cuota = Convert.ToDouble(txtCuota.Text);

            double interes = montoAnterior * 0.02; 

            double nuevoMonto = montoAnterior - cuota;

            txtInteres.Text = interes.ToString("N2");
            txtNuevoMonto.Text = nuevoMonto.ToString("N2");
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (cmbCliente.Text == "" || txtCuota.Text == "")
            {
                MessageBox.Show("Debe completar los campos");
                return;
            }

            MessageBox.Show("Pago registrado correctamente");

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            txtMontoAnterior.Clear();
            txtInteres.Clear();
            txtCuota.Clear();
            txtNuevoMonto.Clear();
            txtMesesRestantes.Clear();
            txtTotalIntereses.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
          
            cmbCliente.SelectedIndex = -1;
            txtMontoAnterior.Clear();
            txtInteres.Clear();
            txtCuota.Clear();
            txtNuevoMonto.Clear();
            txtMesesRestantes.Clear();
            txtTotalIntereses.Clear();
        
    }
    }
}
