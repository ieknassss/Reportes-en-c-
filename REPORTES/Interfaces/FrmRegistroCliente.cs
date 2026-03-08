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

namespace REPORTES.Interfaces
{
    public partial class FrmRegistroCliente : Form
    {
        PrestamosDBEntities db = new PrestamosDBEntities();
        public FrmRegistroCliente()
        {
            InitializeComponent();
            CargarClientes();
        }
        public void CargarClientes()
        {
            dgvClientes.DataSource = db.Clientes.ToList();
        }



        private void FrmRegistroCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtCorreo.Text == "")
            {
                MessageBox.Show("Debe completar todo");
                return;
            }

            Clientes c = new Clientes();

            c.NombreCompleto = txtNombre.Text;
            c.Correo = txtCorreo.Text;
            c.Telefono = txtTelefono.Text;
            c.Direccion = txtDireccion.Text;
            c.Garantia = txtGarantia.Text;
            c.Sueldo = Convert.ToDecimal(txtSueldo.Text);
            c.EsMoroso = checkBox1.Checked;

            db.Clientes.Add(c);
            db.SaveChanges();

            MessageBox.Show("Cliente registrado correctamente");

            CargarClientes();

            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtGarantia.Clear();
            txtSueldo.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
