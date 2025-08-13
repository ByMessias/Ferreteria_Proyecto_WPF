using System;

namespace Ferreteria_Proyecto_WPF.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public byte TipoCliente { get; set; } = 1; // 1 Persona, 2 Empresa

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CedulaRNC { get; set; }

        public int? IdGenero { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdCiudad { get; set; }

        public string DireccionLinea { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; } = true;

        // Para mostrar (resueltos por joins o catálogo)
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
    }

    // Item simple de catálogo
    public class RefItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
