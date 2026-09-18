using Microsoft.Data.SqlClient;

namespace SEMANA04.Data
{
    public static class Conexion
    {
        private const string CadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}
