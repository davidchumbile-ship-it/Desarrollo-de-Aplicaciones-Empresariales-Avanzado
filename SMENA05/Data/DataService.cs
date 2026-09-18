using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using SEMANA04.Models;

namespace SEMANA04.Data
{
    public class DataService
    {
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarProductos", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int colIdProducto = reader.GetOrdinal("idproducto");
                        int colNombreProducto = reader.GetOrdinal("nombreProducto");
                        int colIdProveedor = reader.GetOrdinal("idProveedor");
                        int colIdCategoria = reader.GetOrdinal("idCategoria");
                        int colCantidadPorUnidad = reader.GetOrdinal("cantidadPorUnidad");
                        int colPrecioUnidad = reader.GetOrdinal("precioUnidad");
                        int colUnidadesEnExistencia = reader.GetOrdinal("unidadesEnExistencia");
                        int colUnidadesEnPedido = reader.GetOrdinal("unidadesEnPedido");
                        int colNivelNuevoPedido = reader.GetOrdinal("nivelNuevoPedido");
                        int colSuspendido = reader.GetOrdinal("suspendido");
                        int colCategoriaProducto = reader.GetOrdinal("categoriaProducto");

                        while (reader.Read())
                        {
                            var producto = new Producto
                            {
                                idproducto = reader.IsDBNull(colIdProducto) ? 0 : reader.GetInt32(colIdProducto),
                                nombreProducto = reader.IsDBNull(colNombreProducto) ? string.Empty : reader.GetString(colNombreProducto),
                                idProveedor = reader.IsDBNull(colIdProveedor) ? null : reader.GetInt32(colIdProveedor),
                                idCategoria = reader.IsDBNull(colIdCategoria) ? null : reader.GetInt32(colIdCategoria),
                                cantidadPorUnidad = reader.IsDBNull(colCantidadPorUnidad) ? null : reader.GetString(colCantidadPorUnidad),
                                precioUnidad = reader.IsDBNull(colPrecioUnidad) ? null : Convert.ToDecimal(reader.GetValue(colPrecioUnidad)),
                                unidadesEnExistencia = reader.IsDBNull(colUnidadesEnExistencia) ? null : Convert.ToInt16(reader.GetValue(colUnidadesEnExistencia)),
                                unidadesEnPedido = reader.IsDBNull(colUnidadesEnPedido) ? null : Convert.ToInt16(reader.GetValue(colUnidadesEnPedido)),
                                nivelNuevoPedido = reader.IsDBNull(colNivelNuevoPedido) ? null : Convert.ToInt16(reader.GetValue(colNivelNuevoPedido)),
                                suspendido = reader.IsDBNull(colSuspendido) ? null : Convert.ToBoolean(reader.GetValue(colSuspendido)),
                                categoriaProducto = reader.IsDBNull(colCategoriaProducto) ? null : reader.GetString(colCategoriaProducto)
                            };

                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }

        public List<Categoria> ObtenerCategorias()
        {
            var categorias = new List<Categoria>();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarCategoriasSemana04", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int colIdCategoria = reader.GetOrdinal("idcategoria");
                        int colNombreCategoria = reader.GetOrdinal("nombrecategoria");
                        int colDescripcion = reader.GetOrdinal("descripcion");
                        int colActivo = reader.GetOrdinal("Activo");
                        int colCodCategoria = reader.GetOrdinal("CodCategoria");

                        while (reader.Read())
                        {
                            var categoria = new Categoria
                            {
                                idcategoria = reader.IsDBNull(colIdCategoria) ? 0 : reader.GetInt32(colIdCategoria),
                                nombrecategoria = reader.IsDBNull(colNombreCategoria) ? string.Empty : reader.GetString(colNombreCategoria),
                                descripcion = reader.IsDBNull(colDescripcion) ? null : reader.GetString(colDescripcion),
                                Activo = reader.IsDBNull(colActivo) ? null : Convert.ToBoolean(reader.GetValue(colActivo)),
                                CodCategoria = reader.IsDBNull(colCodCategoria) ? null : reader.GetValue(colCodCategoria).ToString()
                            };

                            categorias.Add(categoria);
                        }
                    }
                }
            }

            return categorias;
        }

        public List<Proveedor> ObtenerProveedores()
        {
            var proveedores = new List<Proveedor>();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("USP_ListarProveedores", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        LeerProveedores(reader, proveedores);
                    }
                }
            }

            return proveedores;
        }

        public List<Proveedor> BuscarProveedores(string nombreContacto, string ciudad)
        {
            var proveedores = new List<Proveedor>();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("USP_BuscarProveedores", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@nombreContacto", SqlDbType.VarChar, 100)
                    {
                        Value = string.IsNullOrWhiteSpace(nombreContacto) ? string.Empty : nombreContacto.Trim()
                    });

                    cmd.Parameters.Add(new SqlParameter("@ciudad", SqlDbType.VarChar, 100)
                    {
                        Value = string.IsNullOrWhiteSpace(ciudad) ? string.Empty : ciudad.Trim()
                    });

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        LeerProveedores(reader, proveedores);
                    }
                }
            }

            return proveedores;
        }

        public List<DetallePedido> ObtenerDetallesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            var detalles = new List<DetallePedido>();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("USP_DetallesPedidosPorFecha", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date) { Value = fechaInicio.Date });
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.Date) { Value = fechaFin.Date });

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int colIdPedido = reader.GetOrdinal("idpedido");
                        int colIdProducto = reader.GetOrdinal("idproducto");
                        int colPrecioUnidad = reader.GetOrdinal("preciounidad");
                        int colCantidad = reader.GetOrdinal("cantidad");
                        int colDescuento = reader.GetOrdinal("descuento");
                        int colFechaPedido = reader.GetOrdinal("FechaPedido");
                        int colIdCliente = reader.GetOrdinal("IdCliente");
                        int colIdEmpleado = reader.GetOrdinal("IdEmpleado");

                        while (reader.Read())
                        {
                            var detalle = new DetallePedido
                            {
                                idpedido = reader.IsDBNull(colIdPedido) ? 0 : reader.GetInt32(colIdPedido),
                                idproducto = reader.IsDBNull(colIdProducto) ? 0 : reader.GetInt32(colIdProducto),
                                preciounidad = reader.IsDBNull(colPrecioUnidad) ? 0m : Convert.ToDecimal(reader.GetValue(colPrecioUnidad)),
                                cantidad = reader.IsDBNull(colCantidad) ? (short)0 : Convert.ToInt16(reader.GetValue(colCantidad)),
                                descuento = reader.IsDBNull(colDescuento) ? 0m : Convert.ToDecimal(reader.GetValue(colDescuento)),
                                FechaPedido = reader.IsDBNull(colFechaPedido) ? null : reader.GetDateTime(colFechaPedido),
                                IdCliente = reader.IsDBNull(colIdCliente) ? null : reader.GetString(colIdCliente),
                                IdEmpleado = reader.IsDBNull(colIdEmpleado) ? null : reader.GetInt32(colIdEmpleado)
                            };

                            detalles.Add(detalle);
                        }
                    }
                }
            }

            return detalles;
        }

        private void LeerProveedores(SqlDataReader reader, List<Proveedor> proveedores)
        {
            int colIdProveedor = reader.GetOrdinal("idProveedor");
            int colNombreCompania = reader.GetOrdinal("nombreCompañia");
            int colNombreContacto = reader.GetOrdinal("nombrecontacto");
            int colCargoContacto = reader.GetOrdinal("cargocontacto");
            int colDireccion = reader.GetOrdinal("direccion");
            int colCiudad = reader.GetOrdinal("ciudad");
            int colRegion = reader.GetOrdinal("region");
            int colCodPostal = reader.GetOrdinal("codPostal");
            int colPais = reader.GetOrdinal("pais");
            int colTelefono = reader.GetOrdinal("telefono");
            int colFax = reader.GetOrdinal("fax");

            while (reader.Read())
            {
                var proveedor = new Proveedor
                {
                    idProveedor = reader.IsDBNull(colIdProveedor) ? 0 : reader.GetInt32(colIdProveedor),
                    nombreCompañia = reader.IsDBNull(colNombreCompania) ? string.Empty : reader.GetString(colNombreCompania),
                    nombrecontacto = reader.IsDBNull(colNombreContacto) ? null : reader.GetString(colNombreContacto),
                    cargocontacto = reader.IsDBNull(colCargoContacto) ? null : reader.GetString(colCargoContacto),
                    direccion = reader.IsDBNull(colDireccion) ? null : reader.GetString(colDireccion),
                    ciudad = reader.IsDBNull(colCiudad) ? null : reader.GetString(colCiudad),
                    region = reader.IsDBNull(colRegion) ? null : reader.GetString(colRegion),
                    codPostal = reader.IsDBNull(colCodPostal) ? null : reader.GetString(colCodPostal),
                    pais = reader.IsDBNull(colPais) ? null : reader.GetString(colPais),
                    telefono = reader.IsDBNull(colTelefono) ? null : reader.GetString(colTelefono),
                    fax = reader.IsDBNull(colFax) ? null : reader.GetString(colFax)
                };

                proveedores.Add(proveedor);
            }
        }
    }
}
