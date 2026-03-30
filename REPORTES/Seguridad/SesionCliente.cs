using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPORTES.Seguridad
{
    public static class SesionCliente
    {
        public static int IdCliente { get; set; }
        public static string NombreCompleto { get; set; }  // Para mostrar en la UI
        public static string Usuario { get; set; }         // Opcional, útil para logs
    }
}