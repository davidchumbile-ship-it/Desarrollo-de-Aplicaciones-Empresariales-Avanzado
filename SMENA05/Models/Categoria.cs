namespace SEMANA04.Models
{
    public class Categoria
    {
        public int idcategoria { get; set; }
        public string nombrecategoria { get; set; } = string.Empty;
        public string? descripcion { get; set; }
        public bool? Activo { get; set; }
        public string? CodCategoria { get; set; }
    }
}
