using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using SEMANA03.Models;

namespace SEMANA03.Data
{
    public class DataService
    {
        #region MODO DESCONECTADO (SqlDataAdapter y DataTable)

        /// <summary>
        /// Obtiene la lista de estudiantes utilizando el modo DESCONECTADO (DataTable).
        /// SqlDataAdapter abre la conexión, llena el DataTable en memoria y cierra la conexión.
        /// </summary>
        public DataTable ObtenerEstudiantesDataTable()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT StudentId, FirstName, LastName FROM Students ORDER BY StudentId ASC";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        /// <summary>
        /// Obtiene la lista de productos utilizando el modo DESCONECTADO (DataTable).
        /// </summary>
        public DataTable ObtenerProductosDataTable()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT ProductId, Name, Price FROM Products ORDER BY ProductId ASC";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        #endregion

        #region MODO CONECTADO (SqlCommand y SqlDataReader)

        /// <summary>
        /// Obtiene la lista de estudiantes utilizando el modo CONECTADO (SqlDataReader).
        /// La conexión se mantiene abierta mientras el DataReader lee secuencialmente fila por fila.
        /// </summary>
        public List<Student> ObtenerEstudiantesDataReader()
        {
            List<Student> lista = new List<Student>();
            string query = "SELECT StudentId, FirstName, LastName FROM Students ORDER BY StudentId ASC";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student s = new Student
                        {
                            StudentId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2)
                        };
                        lista.Add(s);
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Busca estudiantes por nombre utilizando el modo CONECTADO (SqlDataReader) con consulta parametrizada.
        /// </summary>
        public List<Student> BuscarEstudiantesPorNombreDataReader(string nombre)
        {
            List<Student> lista = new List<Student>();
            string query = "SELECT StudentId, FirstName, LastName FROM Students WHERE FirstName LIKE @filtro ORDER BY StudentId ASC";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Parámetro seguro para evitar inyección SQL
                    comando.Parameters.AddWithValue("@filtro", $"%{nombre.Trim()}%");

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student s = new Student
                            {
                                StudentId = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2)
                            };
                            lista.Add(s);
                        }
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Obtiene la lista de productos utilizando el modo CONECTADO (SqlDataReader).
        /// </summary>
        public List<Product> ObtenerProductosDataReader()
        {
            List<Product> lista = new List<Product>();
            string query = "SELECT ProductId, Name, Price FROM Products ORDER BY ProductId ASC";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product p = new Product
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        };
                        lista.Add(p);
                    }
                }
            }

            return lista;
        }

        #endregion
    }
}
