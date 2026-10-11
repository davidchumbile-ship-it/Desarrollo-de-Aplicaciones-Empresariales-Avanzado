using Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DProducto
    {
        private readonly Conexion conexion = new Conexion();

        public List<Producto> Listar()
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Producto_Listar", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            return LeerProductos(cmd);
        }

        public List<Producto> Buscar(string texto)
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Producto_Buscar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Texto", texto);

            return LeerProductos(cmd);
        }

        public void Insertar(Producto producto)
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Producto_Insertar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            AgregarParametros(cmd, producto);

            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Producto producto)
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Producto_Actualizar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
            AgregarParametros(cmd, producto);

            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int idProducto)
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Producto_EliminarLogico", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);

            cmd.ExecuteNonQuery();
        }

        private static void AgregarParametros(SqlCommand cmd, Producto producto)
        {
            cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
            cmd.Parameters.AddWithValue("@CantidadPorUnidad", (object?)producto.CantidadPorUnidad ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PrecioUnidad", producto.PrecioUnidad);
            cmd.Parameters.AddWithValue("@UnidadesEnExistencia", producto.UnidadesEnExistencia);
        }

        private static List<Producto> LeerProductos(SqlCommand cmd)
        {
            List<Producto> lista = new List<Producto>();

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Producto
                {
                    IdProducto = Convert.ToInt32(dr["idproducto"]),
                    NombreProducto = dr["nombreProducto"].ToString() ?? string.Empty,
                    CantidadPorUnidad = dr["cantidadPorUnidad"].ToString(),
                    PrecioUnidad = dr["precioUnidad"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["precioUnidad"]),
                    UnidadesEnExistencia = dr["unidadesEnExistencia"] == DBNull.Value ? (short)0 : Convert.ToInt16(dr["unidadesEnExistencia"]),
                    Eliminado = Convert.ToBoolean(dr["Eliminado"])
                });
            }

            return lista;
        }
    }
}
