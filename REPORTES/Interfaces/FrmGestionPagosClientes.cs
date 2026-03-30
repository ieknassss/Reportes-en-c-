using REPORTES.Calculations;
using REPORTES.Domain;
using REPORTES.Seguridad;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmGestionPagosClientes : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();

        public FrmGestionPagosClientes()
        {
            InitializeComponent();

            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            txtCuota.Enter += txtCuota_Enter;
            txtCuota.Leave += txtCuota_Leave;
        }

        private void FrmGestionPagosClientes_Load(object sender, EventArgs e)
        {
            // 🔴 VALIDAR SESIÓN
            if (SesionCliente.IdCliente == 0)
            {
                MessageBox.Show("No hay sesión activa. Debe iniciar sesión.");
                this.Close();
                return;
            }

            // 🔹 CARGAR PRÉSTAMOS DEL CLIENTE
            var prestamosCliente = db.Prestamos
                .Where(p => p.ClienteId == SesionCliente.IdCliente)
                .Select(p => new
                {
                    p.Id,
                    Descripcion = "Préstamo #" + p.Id +
                                  " | Monto: RD$ " + p.MontoTotal +
                                  " | Fecha: " + p.FechaPrestamo
                })
                .ToList();

            if (!prestamosCliente.Any())
            {
                MessageBox.Show("Este cliente no tiene préstamos.");
                return;
            }

            cmbCliente.DataSource = prestamosCliente;
            cmbCliente.DisplayMember = "Descripcion";
            cmbCliente.ValueMember = "Id";

            cmbCliente.SelectedIndex = 0; // Selección inicial

            // 🔹 BLOQUEAR CAMPOS
            txtMontoAnterior.ReadOnly = true;
            txtMesesRestantes.ReadOnly = true;
            txtTotalIntereses.ReadOnly = true;
            txtInteres.ReadOnly = true;
            txtNuevoMonto.ReadOnly = true;

            // 🔹 PLACEHOLDER
            txtCuota.Text = "Ingrese la cuota a pagar";
            txtCuota.ForeColor = Color.Gray;

            CargarPagos();
        }

        // 🔹 CAMBIO DE PRÉSTAMO
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null) return;

            if (!int.TryParse(cmbCliente.SelectedValue.ToString(), out int prestamoId))
                return;

            var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);

            if (prestamo == null)
            {
                MessageBox.Show("Préstamo no encontrado");
                return;
            }

            decimal monto = prestamo.MontoTotal ?? 0;
            decimal interesesPrevios = prestamo.InteresGenerado ?? 0;
            int meses = prestamo.Meses;

            txtMontoAnterior.Text = monto.ToString("0.00");
            txtMesesRestantes.Text = meses.ToString();
            txtTotalIntereses.Text = interesesPrevios.ToString("0.00");

            // 🔹 CALCULAR CUOTA
            decimal tasaAnual = LoanCalculator.ObtenerTasaAnual(meses);
            decimal cuota = LoanCalculator.CalcularCuotaMensual(monto, tasaAnual, meses);

            txtCuota.Text = cuota.ToString("0.00");
            txtCuota.ForeColor = Color.Black;
        }

        // 🔹 PLACEHOLDER
        private void txtCuota_Enter(object sender, EventArgs e)
        {
            if (txtCuota.Text == "Ingrese la cuota a pagar")
            {
                txtCuota.Text = "";
                txtCuota.ForeColor = Color.Black;
            }
        }

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
            if (txtCuota.Text == "" || txtCuota.Text == "Ingrese la cuota a pagar")
            {
                MessageBox.Show("Ingrese una cuota válida");
                return;
            }

            decimal montoAnterior = Convert.ToDecimal(txtMontoAnterior.Text);
            int mesesRestantes = Convert.ToInt32(txtMesesRestantes.Text);
            decimal interesesPrevios = Convert.ToDecimal(txtTotalIntereses.Text);
            decimal cuota = Convert.ToDecimal(txtCuota.Text);

            var pago = LoanCalculator.CalcularPagoDelMes(
                montoAnterior,
                mesesRestantes,
                interesesPrevios,
                cuota
            );

            txtInteres.Text = pago.InteresAPagar.ToString("0.00");
            txtNuevoMonto.Text = pago.NuevoMontoAdeudado.ToString("0.00");
            txtMesesRestantes.Text = pago.MesesRestantes.ToString();
            txtTotalIntereses.Text = pago.TotalInteresesAcumulados.ToString("0.00");
        }

        // 🔹 REGISTRAR PAGO
        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (txtCuota.Text == "" || txtCuota.Text == "Ingrese la cuota a pagar")
            {
                MessageBox.Show("Debe ingresar una cuota válida");
                return;
            }

            int prestamoId = (int)cmbCliente.SelectedValue;

            // 🔒 VALIDACIÓN EXTRA DE SEGURIDAD
            var prestamo = db.Prestamos
                .FirstOrDefault(p => p.Id == prestamoId && p.ClienteId == SesionCliente.IdCliente);

            if (prestamo == null)
            {
                MessageBox.Show("No tiene permiso para pagar este préstamo.");
                return;
            }

            Pagos nuevoPago = new Pagos
            {
                PrestamoId = prestamoId,
                MontoAnterior = Convert.ToDecimal(txtMontoAnterior.Text),
                InteresPagado = Convert.ToDecimal(txtInteres.Text),
                MontoAbonado = Convert.ToDecimal(txtCuota.Text),
                NuevoMonto = Convert.ToDecimal(txtNuevoMonto.Text),
                FechaPago = DateTime.Now
            };

            db.Pagos.Add(nuevoPago);
            db.SaveChanges();

            MessageBox.Show("Pago registrado correctamente");

            CargarPagos();
            LimpiarCampos();
        }

        // 🔹 CARGAR SOLO PAGOS DEL CLIENTE LOGUEADO
        public void CargarPagos()
        {
            if (SesionCliente.IdCliente == 0)
                return;

            var lista = (from pago in db.Pagos
                         join prestamo in db.Prestamos
                         on pago.PrestamoId equals prestamo.Id
                         where prestamo.ClienteId == SesionCliente.IdCliente
                         select new
                         {
                             pago.Id,
                             Prestamo = "Préstamo #" + pago.PrestamoId,
                             pago.MontoAnterior,
                             pago.InteresPagado,
                             pago.MontoAbonado,
                             pago.NuevoMonto,
                             pago.FechaPago
                         }).ToList();

            dataGridView1.DataSource = lista;
        }

        // 🔹 LIMPIAR
        private void LimpiarCampos()
        {
            if (cmbCliente.Items.Count > 0)
                cmbCliente.SelectedIndex = 0;

            txtMontoAnterior.Clear();
            txtInteres.Clear();
            txtNuevoMonto.Clear();
            txtMesesRestantes.Clear();
            txtTotalIntereses.Clear();

            txtCuota.Text = "Ingrese la cuota a pagar";
            txtCuota.ForeColor = Color.Gray;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}