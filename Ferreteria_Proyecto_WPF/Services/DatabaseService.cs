using System.Data.SqlClient;

namespace Ferreteria_Proyecto_WPF.Services
{
    public static class DatabaseService
    {
        // ✅ Cambia esto por tu cadena real si es diferente
        public static readonly string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=dbFerreteria;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
