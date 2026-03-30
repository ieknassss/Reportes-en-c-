using Microsoft.Reporting.WinForms;
using REPORTES.Domain;
using REPORTES.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmDashboardCliente : Form
    {
        private PrestamosDBEntities db = new PrestamosDBEntities();
        private int ClienteId;

        public FrmDashboardCliente(int clienteId)
        {
            InitializeComponent();
            ClienteId = clienteId;

            this.Load += FrmDashboardCliente_Load;
            btnPagar.Click += btnPagar_Click;
        }

        private void FrmDashboardCliente_Load(object sender, EventArgs e)
        {
            var cliente = db.Clientes.Find(ClienteId);
            if (cliente != null)
                lblNombre.Text = cliente.NombreCompleto;

            CargarPrestamos();

            cmbPrestamos.SelectedIndexChanged -= cmbPrestamos_SelectedIndexChanged;
            cmbPrestamos.SelectedIndexChanged += cmbPrestamos_SelectedIndexChanged;

            if (cmbPrestamos.Items.Count > 0)
                cmbPrestamos.SelectedIndex = 0;
        }

        // 🔥 CARGAR COMBO
        private void CargarPrestamos()
        {
            var lista = db.Prestamos
                .Where(p => p.ClienteId == ClienteId)
                .Select(p => new
                {
                    Id = p.Id,
                    Texto = "Préstamo #" + p.Id + " - $" + p.MontoTotal
                })
                .ToList();

            if (lista.Count == 0)
            {
                MessageBox.Show("Este cliente no tiene préstamos");
                return;
            }

            cmbPrestamos.DataSource = lista;
            cmbPrestamos.DisplayMember = "Texto";
            cmbPrestamos.ValueMember = "Id";
        }

        // 🔥 EVENTO DEL COMBO (CORRECTO)
        private void cmbPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrestamos.SelectedValue == null)
                return;

            if (cmbPrestamos.SelectedValue == null)
                return;

            int prestamoId;

            if (!int.TryParse(cmbPrestamos.SelectedValue.ToString(), out prestamoId))
                return;

            CargarDashboardPorPrestamo(prestamoId);
            CargarReporteAmortizacion(prestamoId);

            dgvPagos.DataSource = db.Pagos
                .Where(p => p.PrestamoId == prestamoId)
                .Select(p => new
                {
                    Fecha = p.FechaPago,
                    Abono = p.MontoAbonado,
                    Interes = p.InteresPagado,
                    Saldo = p.NuevoMonto
                })
                .ToList();
        }
        

        // 🔥 DASHBOARD
        private void CargarDashboardPorPrestamo(int prestamoId)
        {
            var prestamo = db.Prestamos.Find(prestamoId);
            if (prestamo == null) return;

            decimal montoTotal = prestamo.MontoTotal ?? 0;
            lblMonto.Text = montoTotal.ToString("C");

            lblProximoPago.Text = prestamo.FechaProximoPago?.ToShortDateString() ?? "N/A";

            decimal saldoActual = montoTotal;

            var ultimoPago = db.Pagos
                .Where(p => p.PrestamoId == prestamo.Id)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            if (ultimoPago != null)
                saldoActual = ultimoPago.NuevoMonto ?? 0;

            lblBalance.Text = saldoActual.ToString("C");

            // 🎨 ESTADO PASTEL
            if (prestamo.Estado == "Pagado")
            {
                lblEstado.Text = "Pagado";
                cardEstado.BackColor = Color.FromArgb(255, 248, 220); // crema pastel
                lblEstado.ForeColor = Color.Green;
            }
            else
            {
                lblEstado.Text = "Activo";
                lblEstado.ForeColor = Color.DarkOrange;
                cardEstado.BackColor = Color.FromArgb(255, 240, 200);
            }

            decimal progreso = 0;
            if (montoTotal > 0)
                progreso = ((montoTotal - saldoActual) / montoTotal) * 100;

            if (progreso < 0) progreso = 0;
            if (progreso > 100) progreso = 100;

            progressBar1.Value = (int)progreso;
            lblProgreso.Text = progreso.ToString("0.00") + "% pagado";
        }

        // 🔥 REPORTE
        private void CargarReporteAmortizacion(int prestamoId)
        {
            if (this.DesignMode) return; // 🔥 evita error diseñador

            var service = new PrestamoService();
            var datos = service.ObtenerTablaAmortizacion(prestamoId);

            reportViewer1.LocalReport.ReportEmbeddedResource =
                "REPORTES.Reportes.ReporteAmortizacion.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource("Amortizacion", datos)
            );

            reportViewer1.RefreshReport();
        }

        // 🔥 PAGAR
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cmbPrestamos.SelectedItem == null)
                return;

            if (cmbPrestamos.SelectedValue == null)
                return;

            int prestamoId;

            if (!int.TryParse(cmbPrestamos.SelectedValue.ToString(), out prestamoId))
                return;

            var prestamo = db.Prestamos.Find(prestamoId);

            decimal saldoActual = prestamo.MontoTotal ?? 0;

            var ultimoPago = db.Pagos
                .Where(p => p.PrestamoId == prestamo.Id)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            if (ultimoPago != null)
                saldoActual = ultimoPago.NuevoMonto ?? 0;

            if (saldoActual <= 0)
            {
                MessageBox.Show("Ya está saldado");
                return;
            }

            decimal interes = saldoActual * 0.05m;
            decimal abono = 1000m;
            decimal nuevoSaldo = saldoActual - abono;

            if (nuevoSaldo < 0)
                nuevoSaldo = 0;

            var pago = new Pagos()
            {
                PrestamoId = prestamo.Id,
                MontoAnterior = saldoActual,
                InteresPagado = interes,
                MontoAbonado = abono,
                NuevoMonto = nuevoSaldo,
                FechaPago = DateTime.Now
            };

            db.Pagos.Add(pago);

            prestamo.FechaProximoPago = DateTime.Now.AddMonths(1);

            if (prestamo.Meses > 0)
                prestamo.Meses--;

            if (prestamo.Meses == 0 || nuevoSaldo == 0)
                prestamo.Estado = "Pagado";

            db.SaveChanges();

            MessageBox.Show("Pago realizado");

            // 🔥 refresca todo
            cmbPrestamos_SelectedIndexChanged(null, null);
        }

        private void cardEstado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}