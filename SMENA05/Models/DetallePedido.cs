using System;

namespace SEMANA04.Models
{
    public class DetallePedido
    {
        public int idpedido { get; set; }
        public int idproducto { get; set; }
        public decimal preciounidad { get; set; }
        public short cantidad { get; set; }
        public decimal descuento { get; set; }
        public DateTime? FechaPedido { get; set; }
        public string? IdCliente { get; set; }
        public int? IdEmpleado { get; set; }
    }
}
