using System;
using System.Collections.Generic;

namespace BlazorServer.Entities
{
    public class Factura
    {   
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }

        /// <summary>
        /// Una factura pertenece a un cliente
        /// </summary>
        public virtual Cliente Cliente { get; set; } = null!;

        /// <summary>
        /// Una factura tiene muchos detalles
        /// </summary>
        public virtual ICollection<DetalleFactura> DetallesFacturas { get; set; }
    }
}
