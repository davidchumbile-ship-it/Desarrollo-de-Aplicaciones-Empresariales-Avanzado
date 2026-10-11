namespace Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string? CantidadPorUnidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public short UnidadesEnExistencia { get; set; }
        public bool Eliminado { get; set; }
    }
}
