using System;
using System.Collections.Generic;

namespace BlazorServer.Entities
{
    public class Cliente
    {
     
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Un cliente tiene muchas facturas
        /// </summary>
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
