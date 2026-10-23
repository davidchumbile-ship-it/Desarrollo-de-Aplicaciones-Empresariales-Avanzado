using System.ComponentModel.DataAnnotations;

namespace LaboratorioCRUDAlumnos.Models
{
    public class AlumnoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        public string Correo { get; set; }
    }
}
