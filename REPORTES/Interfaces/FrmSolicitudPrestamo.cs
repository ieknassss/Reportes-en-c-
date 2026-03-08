using REPORTES.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using REPORTES.Calculations;

namespace REPORTES.Interfaces
{
    public partial class FrmSolicitudPrestamo : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();
        public FrmSolicitudPrestamo()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal monto = Convert.ToDecimal(txtMonto.Text);
            int meses = Convert.ToInt32(txtMeses.Text);

            decimal tasaAnual = LoanCalculator.ObtenerTasaAnual(meses);

            decimal interes = LoanCalculator.CalcularInteresSimple(monto, tasaAnual, meses);

            decimal montoTotal = LoanCalculator.CalcularMontoTotal(monto, interes);

            decimal cuota = LoanCalculator.CalcularCuotaMensual(monto, tasaAnual, meses);

            txtInteres.Text = interes.ToString();
            txtTotal.Text = montoTotal.ToString();
            txtCuota.Text = cuota.ToString();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMonto.Clear();
            txtMeses.Clear();
            txtInteres.Clear();
            txtTotal.Clear();
            txtCuota.Clear();
        }

        public void CargarPrestamos()
        {
            dataGridView1.DataSource = db.Prestamos
                .Select(p => new
                {
                    p.Id,
                    Cliente = p.Clientes.NombreCompleto,
                    p.Monto,
                    p.Meses,
                    p.InteresGenerado,
                    p.MontoTotal,
                    p.FechaPrestamo
                }).ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.Text == "" || txtMonto.Text == "" || txtMeses.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Prestamos  p = new Prestamos();

            p.ClienteId = (int)cmbCliente.SelectedValue;
            p.Monto = Convert.ToDecimal(txtMonto.Text);
            p.Meses = Convert.ToInt32(txtMeses.Text);
            p.InteresGenerado = Convert.ToDecimal(txtInteres.Text);
            p.MontoTotal = Convert.ToDecimal(txtTotal.Text);
            p.FechaPrestamo = DateTime.Now;

            db.Prestamos.Add(p);
            db.SaveChanges();
            CargarPrestamos();

            MessageBox.Show("Prestamo guardado correctamente");

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

        private void FrmSolicitudPrestamo_Load(object sender, EventArgs e)
        {
            cmbCliente.DataSource = db.Clientes.ToList();
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "Id";

            CargarPrestamos();
        }
    }
}
