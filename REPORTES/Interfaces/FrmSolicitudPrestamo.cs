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
    public partial class FrmSolicitudPrestamo : Form
    {
        public FrmSolicitudPrestamo()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double monto = Convert.ToDouble(txtMonto.Text);
            int meses = Convert.ToInt32(txtMeses.Text);

            double tasa = 0;

            if (meses <= 12)
                tasa = 13.25;
            else if (meses <= 24)
                tasa = 15;
            else
                tasa = 30;

            double interes = monto * (tasa / 100);
            double total = monto + interes;
            double cuota = total / meses;

            txtInteres.Text = interes.ToString("N2");
            txtTotal.Text = total.ToString("N2");
            txtCuota.Text = cuota.ToString("N2");

           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMonto.Clear();
            txtMeses.Clear();
            txtInteres.Clear();
            txtTotal.Clear();
            txtCuota.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.Text == "" || txtMonto.Text == "" || txtMeses.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Préstamo registrado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
     
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            txtMonto.Clear();
            txtMeses.Clear();
            txtInteres.Clear();
            txtTotal.Clear();
            txtCuota.Clear();
        }
    }
}
