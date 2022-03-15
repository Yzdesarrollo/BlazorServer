using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public string Nombres { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;

        [Required(ErrorMessage ="Campo obligatorio")]
        public string Apellidos { get; set; } = null!;

        [Required(ErrorMessage ="Campo obligatorio")]
        public string? Identificacion { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email no válido")]
        public string? Email { get; set; }
    }
}
