using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public class LoginUsuarioModel
    {
        [Required(ErrorMessage = "El email es requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "La dirección no es válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
