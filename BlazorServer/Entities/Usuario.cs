using System;
using System.Collections.Generic;

namespace BlazorServer.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string Nombre  { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Clave { get; set; } = null!;

        /// <summary>
        /// Un Usuario tiene un solo rol
        /// </summary>
        public virtual Rol Rol { get; set; } = null!;
    }
}
