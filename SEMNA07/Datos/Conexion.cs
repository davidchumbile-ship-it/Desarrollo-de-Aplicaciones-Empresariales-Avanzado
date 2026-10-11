using Microsoft.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}
