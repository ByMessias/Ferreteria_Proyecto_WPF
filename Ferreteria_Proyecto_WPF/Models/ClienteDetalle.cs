using System;

namespace Ferreteria_Proyecto_WPF.Models
{
    public class ClienteDetalle
    {
        public int IdCliente { get; set; }
        public byte TipoCliente { get; set; } = 1; // 1 Persona, 2 Empresa
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CedulaRNC { get; set; }
        public int? IdGenero { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Activo { get; set; } = true;
        public string Notas { get; set; }

        // Contacto “principal” (opcional por ahora)
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
