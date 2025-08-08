using Ferreteria_Proyecto_WPF.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferreteria_Proyecto_WPF.Services
{
    public static class ClienteService
    {
        public static List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (var conn = DatabaseService.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT c.cliente_id, c.cliente_nombre, c.cliente_apellido, c.cliente_cedula, 
                       c.cliente_fecha_nacimiento, c.direccion_numero, c.direccion_ciudad_id, 
                       c.cliente_correo_electronico, c.usuario_id, c.provincia_id, c.genero_id,
                       ci.ciudad_nombre, p.provincia_nombre, g.generos
                FROM clientes c
                LEFT JOIN ciudades ci ON ci.ciudad_id = c.direccion_ciudad_id
                LEFT JOIN provincias p ON p.provincia_id = c.provincia_id
                LEFT JOIN generos g ON g.genero_id = c.genero_id";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            ClienteId = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Cedula = reader.IsDBNull(3) ? null : reader.GetString(3),
                            FechaNacimiento = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                            DireccionNumero = reader.IsDBNull(5) ? null : reader.GetString(5),
                            DireccionCiudadId = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                            CorreoElectronico = reader.IsDBNull(7) ? null : reader.GetString(7),
                            UsuarioId = reader.IsDBNull(8) ? null : reader.GetInt32(8),
                            ProvinciaId = reader.IsDBNull(9) ? null : reader.GetInt32(9),
                            GeneroId = reader.IsDBNull(10) ? null : reader.GetInt32(10),
                            CiudadNombre = reader.IsDBNull(11) ? null : reader.GetString(11),
                            ProvinciaNombre = reader.IsDBNull(12) ? null : reader.GetString(12),
                            GeneroNombre = reader.IsDBNull(13) ? null : reader.GetString(13),
                        });
                    }
                }
            }

            return clientes;
        }
    }
}