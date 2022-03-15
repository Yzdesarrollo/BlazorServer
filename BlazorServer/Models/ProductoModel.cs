using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public class ProductoModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Referencia { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public decimal Costo { get; set; }
        public int? Stock { get; set; }
        /// <summary>
        /// Propiedad de solo lectura no lleva { get; set; }
        /// </summary>
        public decimal Margen => (Precio - Costo);
    }
}
