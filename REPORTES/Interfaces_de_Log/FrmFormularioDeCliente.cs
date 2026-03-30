using REPORTES.Interfaces;
using REPORTES.Seguridad;
using System;
using System.Linq;
using System.Windows.Forms;

namespace REPORTES.Interfaces_de_Log
{
    public partial class FrmFormularioDeCliente : Form
    {
        public FrmFormularioDeCliente()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtClave.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
                return;
            }

            using (PrestamosDBEntities db = new PrestamosDBEntities())
            {
                var cliente = db.Clientes
                    .FirstOrDefault(c => c.Usuario == txtUsuario.Text
                                      && c.Clave == txtClave.Text);

                if (cliente != null)
                {
                    MessageBox.Show("Bienvenido " + cliente.NombreCompleto);

                    // Guardar sesión
                    SesionCliente.IdCliente = cliente.Id;
                    SesionCliente.NombreCompleto = cliente.NombreCompleto;
                    SesionCliente.Usuario = cliente.Usuario;

                    this.Hide();

                    // ✅ AQUÍ ESTÁ LA CLAVE
                    FrmMenuClientes menu = new FrmMenuClientes(cliente.Id, cliente.Usuario);
                    menu.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
        }

        private void FrmFormularioDeCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void FrmFormularioDeCliente_Load_1(object sender, EventArgs e)
        {

        }
    }
}