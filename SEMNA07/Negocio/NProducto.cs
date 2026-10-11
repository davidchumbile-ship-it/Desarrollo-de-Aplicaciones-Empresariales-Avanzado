using Datos;
using Entidades;

namespace Negocio
{
    public class NProducto
    {
        private readonly DProducto dProducto = new DProducto();

        public List<Producto> Listar()
        {
            return dProducto.Listar();
        }

        public List<Producto> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return dProducto.Listar();

            return dProducto.Buscar(texto.Trim());
        }

        public void Registrar(Producto producto)
        {
            Validar(producto);
            dProducto.Insertar(producto);
        }

        public void Actualizar(Producto producto)
        {
            if (producto.IdProducto <= 0)
                throw new ArgumentException("Seleccione un producto de la lista.");

            Validar(producto);
            dProducto.Actualizar(producto);
        }

        public void Eliminar(int idProducto)
        {
            if (idProducto <= 0)
                throw new ArgumentException("Seleccione un producto de la lista.");

            dProducto.Eliminar(idProducto);
        }

        private static void Validar(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.NombreProducto))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            if (producto.NombreProducto.Length > 40)
                throw new ArgumentException("El nombre no puede superar 40 caracteres.");

            if (producto.PrecioUnidad < 0)
                throw new ArgumentException("El precio no puede ser negativo.");

            if (producto.UnidadesEnExistencia < 0)
                throw new ArgumentException("El stock no puede ser negativo.");
        }
    }
}
