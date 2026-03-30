using REPORTES.Seguridad;
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
    public partial class FrmVisualizacionDatosCliente : Form
    {
        PrestamosDBEntities db;
        public FrmVisualizacionDatosCliente()
        {
            InitializeComponent();
        }

        private void btnVerPrestamos_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = db.Prestamos
                .Where(p => p.ClienteId == SesionCliente.IdCliente) // 🔹 FILTRAR POR CLIENTE LOGUEADO
                .Select(p => new
                {
                    p.Id,
                    Cliente = p.Clientes.NombreCompleto,
                    p.Monto,
                    p.Meses,
                    p.InteresGenerado,
                    p.MontoTotal,
                    p.FechaPrestamo
                }).ToList();
        }

        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = db.Pagos
                .Where(p => p.Prestamos.ClienteId == SesionCliente.IdCliente) // 🔹 FILTRAR POR CLIENTE LOGUEADO
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

        private void FrmVisualizacionDatos_Load(object sender, EventArgs e)
        {
            db = new PrestamosDBEntities();
        }
    }
}
