using REPORTES.Calculations;
using REPORTES.Seguridad;
using REPORTES.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmSolicitudPrestamoCliente : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();
        PrestamoService prestamoService = new PrestamoService();

        public FrmSolicitudPrestamoCliente()
        {
            InitializeComponent();
        }

        private void FrmSolicitudPrestamo_Load(object sender, EventArgs e)
        {
            // 🔴 VALIDAR SESIÓN
            if (SesionCliente.IdCliente == 0)
            {
                MessageBox.Show("Debe iniciar sesión.");
                this.Close();
                return;
            }

            // 🔹 CARGAR SOLO EL CLIENTE LOGUEADO
            var cliente = db.Clientes
                .Where(c => c.Id == SesionCliente.IdCliente)
                .ToList();

            cmbCliente.DataSource = cliente;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "Id";

            cmbCliente.SelectedValue = SesionCliente.IdCliente;

            // 🔒 BLOQUEAR CAMBIO (SEGURIDAD)
            cmbCliente.Enabled = false;

            CargarPrestamos();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMonto.Text) || string.IsNullOrWhiteSpace(txtMeses.Text))
                {
                    MessageBox.Show("Debe completar monto y meses.");
                    return;
                }

                decimal monto;
                int meses;

                if (!decimal.TryParse(txtMonto.Text, out monto))
                {
                    MessageBox.Show("Monto inválido.");
                    return;
                }

                if (!int.TryParse(txtMeses.Text, out meses))
                {
                    MessageBox.Show("Meses inválidos.");
                    return;
                }

                decimal tasaAnual = LoanCalculator.ObtenerTasaAnual(meses);
                decimal interes = LoanCalculator.CalcularInteresSimple(monto, tasaAnual, meses);
                decimal total = LoanCalculator.CalcularMontoTotal(monto, interes);
                decimal cuota = LoanCalculator.CalcularCuotaMensual(monto, tasaAnual, meses);

                txtInteres.Text = interes.ToString("N2");
                txtTotal.Text = total.ToString("N2");
                txtCuota.Text = cuota.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMonto.Text) || string.IsNullOrWhiteSpace(txtMeses.Text))
                {
                    MessageBox.Show("Complete los campos.");
                    return;
                }

                decimal monto;
                int meses;

                if (!decimal.TryParse(txtMonto.Text, out monto))
                {
                    MessageBox.Show("Monto inválido.");
                    return;
                }

                if (!int.TryParse(txtMeses.Text, out meses))
                {
                    MessageBox.Show("Meses inválidos.");
                    return;
                }

                int clienteId = SesionCliente.IdCliente; // 🔒 SIEMPRE EL LOGUEADO

                prestamoService.CrearPrestamo(clienteId, monto, meses);

                MessageBox.Show("Préstamo guardado correctamente.");

                db = new PrestamosDBEntities(); // refrescar contexto
                CargarPrestamos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 🔥 SOLO PRÉSTAMOS DEL CLIENTE LOGUEADO
        public void CargarPrestamos()
        {
            if (SesionCliente.IdCliente == 0)
                return;

            var lista = db.Prestamos
                .Where(p => p.ClienteId == SesionCliente.IdCliente)
                .Select(p => new
                {
                    p.Id,
                    Cliente = p.Clientes.NombreCompleto,
                    p.Monto,
                    p.Meses,
                    p.InteresGenerado,
                    p.MontoTotal,
                    p.FechaPrestamo
                })
                .ToList();

            dataGridView1.DataSource = lista;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedValue = SesionCliente.IdCliente;
            txtMonto.Clear();
            txtMeses.Clear();
            txtInteres.Clear();
            txtTotal.Clear();
            txtCuota.Clear();
        }
    }
}