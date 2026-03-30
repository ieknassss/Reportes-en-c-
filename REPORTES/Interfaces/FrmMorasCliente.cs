using REPORTES.Calculations;
using REPORTES.Domain;
using REPORTES.Seguridad;
using System;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmMorasCliente : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();

        public FrmMorasCliente()
        {
            InitializeComponent();
            cmbPrestamo.SelectedIndexChanged += cmbPrestamo_SelectedIndexChanged;
        }

        private void FrmMoras_Load(object sender, EventArgs e)
        {
            // 🔴 Validar sesión
            if (SesionCliente.IdCliente == 0)
            {
                MessageBox.Show("Debe iniciar sesión.");
                this.Close();
                return;
            }

            // 🔹 SOLO préstamos del cliente logueado
            var prestamosCliente = db.Prestamos
                .Where(p => p.ClienteId == SesionCliente.IdCliente)
                .Select(p => new
                {
                    p.Id,
                    Descripcion = "Préstamo #" + p.Id +
                                  " | Monto: " + p.MontoTotal +
                                  " | Meses: " + p.Meses
                }).ToList();

            cmbPrestamo.DataSource = prestamosCliente;
            cmbPrestamo.DisplayMember = "Descripcion";
            cmbPrestamo.ValueMember = "Id";

            if (prestamosCliente.Any())
                cmbPrestamo.SelectedIndex = 0;

            // 🔒 No editable
            txtCuotaMensual.ReadOnly = true;

            CargarMoras();
        }

        // 🔥 AQUÍ SE CALCULA AUTOMÁTICAMENTE LA CUOTA
        private void cmbPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrestamo.SelectedValue == null) return;

            int prestamoId;
            if (!int.TryParse(cmbPrestamo.SelectedValue.ToString(), out prestamoId))
                return;

            var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);

            if (prestamo == null) return;

            decimal monto = prestamo.MontoTotal ?? 0;
            int meses = prestamo.Meses;

            decimal tasaAnual = LoanCalculator.ObtenerTasaAnual(meses);
            decimal cuota = LoanCalculator.CalcularCuotaMensual(monto, tasaAnual, meses);

            txtCuotaMensual.Text = cuota.ToString("0.00");
        }

        // 🔒 SOLO MORAS DEL CLIENTE
        public void CargarMoras()
        {
            var lista = (from mora in db.Moras
                         join prestamo in db.Prestamos
                         on mora.PrestamoId equals prestamo.Id
                         where prestamo.ClienteId == SesionCliente.IdCliente
                         select new
                         {
                             mora.Id,
                             Prestamo = "Préstamo #" + mora.PrestamoId,
                             mora.Cantidad
                         }).ToList();

            dgvMoras.DataSource = lista;
        }

        private void btnCalcularMora_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCuotaMensual.Text))
            {
                MessageBox.Show("Seleccione un préstamo primero.");
                return;
            }

            decimal cuota = Convert.ToDecimal(txtCuotaMensual.Text);

            decimal mora = LoanCalculator.CalcularMora(cuota);

            txtMora.Text = mora.ToString("0.00");
        }

        private void btnRegistrarMora_Click(object sender, EventArgs e)
        {
            decimal cantidadMora;

            if (!decimal.TryParse(txtMora.Text, out cantidadMora))
            {
                MessageBox.Show("Ingrese un valor válido");
                return;
            }

            int prestamoId = (int)cmbPrestamo.SelectedValue;

            // 🔒 Validación de seguridad
            var prestamo = db.Prestamos
                .FirstOrDefault(p => p.Id == prestamoId && p.ClienteId == SesionCliente.IdCliente);

            if (prestamo == null)
            {
                MessageBox.Show("No autorizado.");
                return;
            }

            Moras nuevaMora = new Moras
            {
                PrestamoId = prestamoId,
                Cantidad = (int)cantidadMora
            };

            db.Moras.Add(nuevaMora);
            db.SaveChanges();

            MessageBox.Show("Mora registrada correctamente");

            CargarMoras();
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            txtMora.Clear();
        }
    }
}