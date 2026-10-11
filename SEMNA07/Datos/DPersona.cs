using Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DPersona
    {
        private readonly Conexion conexion = new Conexion();

        public List<Persona> Listar()
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Persona_Listar", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            return LeerPersonas(cmd);
        }

        public List<Persona> Buscar(string texto)
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Persona_Buscar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Texto", texto);

            return LeerPersonas(cmd);
        }

        public void Insertar(Persona persona)
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Persona_Insertar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            AgregarParametros(cmd, persona);

            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Persona persona)
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Persona_Actualizar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
            AgregarParametros(cmd, persona);

            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int idPersona)
        {
            using SqlConnection connection = conexion.ObtenerConexion();
            connection.Open();

            using SqlCommand cmd = new SqlCommand("USP_Persona_EliminarLogico", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdPersona", idPersona);

            cmd.ExecuteNonQuery();
        }

        private static void AgregarParametros(SqlCommand cmd, Persona persona)
        {
            cmd.Parameters.AddWithValue("@Nombres", persona.Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
            cmd.Parameters.AddWithValue("@Dni", persona.Dni);
            cmd.Parameters.AddWithValue("@Telefono", (object?)persona.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)persona.Email ?? DBNull.Value);
        }

        private static List<Persona> LeerPersonas(SqlCommand cmd)
        {
            List<Persona> lista = new List<Persona>();

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Persona
                {
                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                    Nombres = dr["Nombres"].ToString() ?? string.Empty,
                    Apellidos = dr["Apellidos"].ToString() ?? string.Empty,
                    Dni = dr["Dni"].ToString() ?? string.Empty,
                    Telefono = dr["Telefono"].ToString(),
                    Email = dr["Email"].ToString(),
                    Eliminado = Convert.ToBoolean(dr["Eliminado"])
                });
            }

            return lista;
        }
    }
}
