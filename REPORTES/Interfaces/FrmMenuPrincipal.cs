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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroCliente frm = new FrmRegistroCliente();
            frm.ShowDialog();
        }

        private void solicitarPréstamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSolicitudPrestamo frm = new FrmSolicitudPrestamo();
            frm.ShowDialog();
        }

        private void gestiónDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionPagos frm = new FrmGestionPagos();
            frm.ShowDialog();
        }

        private void verInformaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualizacionDatos frm = new FrmVisualizacionDatos();
            frm.ShowDialog();
        }
    }
}
