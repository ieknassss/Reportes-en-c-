using REPORTES.Reportes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces
{
    public partial class FrmMenuClientes : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();
      
            // Variables para guardar la sesión del cliente
        private int clienteId;
        private string usuario;

        // Constructor que recibe datos del login (RECOMENDADO)
        public FrmMenuClientes(int id, string user)
        {
            InitializeComponent();
            clienteId = id;
            usuario = user;
        }

        public FrmMenuClientes()
        {
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroCliente frm = new FrmRegistroCliente();
            frm.ShowDialog();
        }

        private void solicitarPréstamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSolicitudPrestamoCliente frm = new FrmSolicitudPrestamoCliente();
            frm.ShowDialog();
        }

        private void gestiónDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionPagosClientes frm = new FrmGestionPagosClientes();
            frm.ShowDialog();
        }

        private void verInformaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualizacionDatosCliente frm = new FrmVisualizacionDatosCliente();
            frm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tablaDeAmortizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void informaciónDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformacionCliente frm = new FrmInformacionCliente();
            frm.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void totalPrestadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTotalPrestado frm = new FrmTotalPrestado();
            frm.Show();
        }

        private void morasAcumuladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMorasAcumuladas frm = new FrmMorasAcumuladas();
            frm.Show();
        }

        private void clientesMorososToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesMorosos frm = new FrmClientesMorosos();
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void visualizacionDeMorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void adminsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroAdmin frm = new FrmRegistroAdmin();
            frm.Show();
        }

        private void FrmMenuClientes_Load(object sender, EventArgs e)
        {

        }

        private void sistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void morasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void morasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void morasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmMorasCliente frm = new FrmMorasCliente();
            frm.Show();
        }

        private void amortizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDashboardCliente frm = new FrmDashboardCliente(clienteId);
            frm.Show();
        }

        private void informacionDelPropietarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDashboardCliente frm = new FrmDashboardCliente(clienteId);
            frm.Show();
        }
    }
}
