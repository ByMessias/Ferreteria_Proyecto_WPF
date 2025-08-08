using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria_Proyecto_WPF.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string DireccionNumero { get; set; }
        public int? DireccionCiudadId { get; set; }
        public string CorreoElectronico { get; set; }
        public int? UsuarioId { get; set; }
        public int? ProvinciaId { get; set; }
        public int? GeneroId { get; set; }

        // Datos auxiliares (de FK)
        public string CiudadNombre { get; set; }
        public string ProvinciaNombre { get; set; }
        public string GeneroNombre { get; set; }
    }
}
