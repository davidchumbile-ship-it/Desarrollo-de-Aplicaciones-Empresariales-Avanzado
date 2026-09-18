namespace SEMANA04.Models
{
    public class Producto
    {
        public int idproducto { get; set; }
        public string nombreProducto { get; set; } = string.Empty;
        public int? idProveedor { get; set; }
        public int? idCategoria { get; set; }
        public string? cantidadPorUnidad { get; set; }
        public decimal? precioUnidad { get; set; }
        public short? unidadesEnExistencia { get; set; }
        public short? unidadesEnPedido { get; set; }
        public short? nivelNuevoPedido { get; set; }
        public bool? suspendido { get; set; }
        public string? categoriaProducto { get; set; }
    }
}
