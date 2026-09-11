using Microsoft.Data.SqlClient;

namespace SEMANA03.Data
{
    public static class Conexion
    {
        private static readonly string CadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Tecsup2026DB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}
