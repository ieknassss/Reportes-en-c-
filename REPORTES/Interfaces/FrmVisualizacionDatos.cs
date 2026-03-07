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
    public partial class FrmVisualizacionDatos : Form
    {
        public FrmVisualizacionDatos()
        {
            InitializeComponent();
        }

        private void btnVerClientes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se mostrarán los clientes registrados");
        }

        private void btnVerPrestamos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se mostrarán los préstamos registrados");
        }

        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se mostrarán los pagos realizados");
        }
    }
}
