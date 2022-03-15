using System;
using System.Collections.Generic;

namespace BlazorServer.Entities
{
    public class Producto
    {
     

        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Referencia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public int? Stock { get; set; }

        /// <summary>
        /// Un producto tiene una categoria
        /// </summary>
        /// 
        public virtual Categoria Categoria { get; set; } = null!;

        /// <summary>
        /// Un producto esta en muchos detalles de Factura
        /// </summary>
        public virtual ICollection<DetalleFactura> DetallesFacturas { get; set; }
    }
}
