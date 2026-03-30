using REPORTES.Calculations;
using REPORTES.Domain;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using REPORTES.Interfaces;

namespace REPORTES.Interfaces
{
    public partial class FrmGestionPagos : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();

        public FrmGestionPagos()
        {
            InitializeComponent();
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            txtCuota.Enter += txtCuota_Enter;
            txtCuota.Leave += txtCuota_Leave;
        }

        private void FrmGestionPagos_Load(object sender, EventArgs e)
        {
            // Cargar clientes
            cmbCliente.DataSource = db.Prestamos
                .Select(p => new
                {
                    p.Id,
                    Cliente = p.Clientes.NombreCompleto
                }).ToList();

            cmbCliente.DisplayMember = "Cliente";
            cmbCliente.ValueMember = "Id";
            cmbCliente.SelectedIndex = -1;

            // BLOQUEAR CAMPOS
            txtMontoAnterior.ReadOnly = true;
            txtMesesRestantes.ReadOnly = true;
            txtTotalIntereses.ReadOnly = true;
            txtInteres.ReadOnly = true;
            txtNuevoMonto.ReadOnly = true;

            // Placeholder cuota
            txtCuota.Text = "Ingrese la cuota a pagar";
            txtCuota.ForeColor = Color.Gray;

            CargarPagos();
        }

        // 🔹 AUTOCARGAR DATOS AL SELECCIONAR CLIENTE
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null) return;

            if (!int.TryParse(cmbCliente.SelectedValue.ToString(), out int prestamoId))
                return;

            var prestamo = db.Prestamos
                .Where(p => p.Id == prestamoId)
                .FirstOrDefault();

            if (prestamo == null)
            {
                MessageBox.Show("No se encontró el préstamo");
                return;
            }

            // 🔹 Mostrar datos actuales (manejo de nullables)
            decimal monto = prestamo.MontoTotal.GetValueOrDefault();
            decimal interesesPrevios = prestamo.InteresGenerado.GetValueOrDefault();
            int meses = prestamo.Meses;

            txtMontoAnterior.Text = monto.ToString("0.00");
            txtMesesRestantes.Text = meses.ToString();
            txtTotalIntereses.Text = interesesPrevios.ToString("0.00");

            // 🔹 Calcular cuota prestablecida automáticamente
            decimal tasaAnual = LoanCalculator.ObtenerTasaAnual(meses);
            decimal cuotaPrestablecida = LoanCalculator.CalcularCuotaMensual(monto, tasaAnual, meses);

            txtCuota.Text = cuotaPrestablecida.ToString("0.00"); // mostrar redondeado
            txtCuota.ForeColor = Color.Black;
        }

        // 🔹 PLACEHOLDER (ENTRAR)
        private void txtCuota_Enter(object sender, EventArgs e)
        {
            if (txtCuota.Text == "Ingrese la cuota a pagar")
            {
                txtCuota.Text = "";
                txtCuota.ForeColor = Color.Black;
            }
        }

        // 🔹 PLACEHOLDER (SALIR)
        private void txtCuota_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCuota.Text))
            {
                txtCuota.Text = "Ingrese la cuota a pagar";
                txtCuota.ForeColor = Color.Gray;
            }
        }

        // 🔹 CALCULAR PAGO
        private void btnCalcularPago_Click(object sender, EventArgs e)
        {
            if (txtCuota.Text == "Ingrese la cuota a pagar" || txtCuota.Text == "")
            {
                MessageBox.Show("Ingrese una cuota válida");
                return;
            }

            decimal montoAnterior = Convert.ToDecimal(txtMontoAnterior.Text);
            int mesesRestantes = Convert.ToInt32(txtMesesRestantes.Text);
            decimal interesesPrevios = Convert.ToDecimal(txtTotalIntereses.Text);
            decimal abonoExtra = Convert.ToDecimal(txtCuota.Text);

            var pago = LoanCalculator.CalcularPagoDelMes(
                montoAnterior,
                mesesRestantes,
                interesesPrevios,
                abonoExtra
            );

            txtInteres.Text = pago.InteresAPagar.ToString("0.00");
            txtNuevoMonto.Text = pago.NuevoMontoAdeudado.ToString("0.00");
            txtMesesRestantes.Text = pago.MesesRestantes.ToString();
            txtTotalIntereses.Text = pago.TotalInteresesAcumulados.ToString("0.00");
        }

        // 🔹 REGISTRAR PAGO
        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (cmbCliente.Text == "" || txtCuota.Text == "" || txtCuota.Text == "Ingrese la cuota a pagar")
            {
                MessageBox.Show("Debe completar los campos");
                return;
            }

            Pagos pago = new Pagos();

            pago.PrestamoId = (int)cmbCliente.SelectedValue;
            pago.MontoAnterior = Convert.ToDecimal(txtMontoAnterior.Text);
            pago.InteresPagado = Convert.ToDecimal(txtInteres.Text);
            pago.MontoAbonado = Convert.ToDecimal(txtCuota.Text);
            pago.NuevoMonto = Convert.ToDecimal(txtNuevoMonto.Text);
            pago.FechaPago = DateTime.Now;

            db.Pagos.Add(pago);
            db.SaveChanges();

            CargarPagos();
            LimpiarCampos();
        }

        // 🔹 CARGAR PAGOS EN GRID
        public void CargarPagos()
        {
            dataGridView1.DataSource = db.Pagos
                .Select(p => new
                {
                    p.Id,
                    p.PrestamoId,
                    p.MontoAnterior,
                    p.InteresPagado,
                    p.MontoAbonado,
                    p.NuevoMonto,
                    p.FechaPago
                }).ToList();
        }

        // 🔹 LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;

            txtMontoAnterior.Clear();
            txtInteres.Clear();
            txtNuevoMonto.Clear();
            txtMesesRestantes.Clear();
            txtTotalIntereses.Clear();

            // Reset placeholder
            txtCuota.Text = "Ingrese la cuota a pagar";
            txtCuota.ForeColor = Color.Gray;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtMontoAnterior_TextChanged(object sender, EventArgs e)
        {
            // vacío (evita error del diseñador)
        }
    }
}