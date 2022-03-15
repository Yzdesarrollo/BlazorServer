using BlazorServer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public class RegistroUsuarioModel
    {
        public int Id { get; set; }
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El email es requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "La dirección no es válida")]
        public string Email { get; set; }


        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres")]
        public string Clave { get; set; }


        [Required(ErrorMessage = "La confirmación de la contraseña es requerida")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres")]
        [Compare("Clave", ErrorMessage = "La confirmación no coincide con la contraseña")]
        public string ConfirmPassword { get; set; }
    }
}
