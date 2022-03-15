using System;
using System.Collections.Generic;

namespace BlazorServer.Entities
{
    public partial class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }

        /// <summary>
        /// Un Detalle de factura estan en una factura
        /// </summary>
        public virtual Factura Factura { get; set; }

        /// <summary>
        /// Detalle de Factura tiene un producto
        /// </summary>
        public virtual Producto Producto { get; set; }
    }
}
