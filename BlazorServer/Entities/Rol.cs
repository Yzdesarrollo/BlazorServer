using System;
using System.Collections.Generic;

namespace BlazorServer.Entities
{
    public class Rol
    {
     
        public int Id { get; set; }
        public string Nombre { get; set; }

        /// <summary>
        /// Un Rol tiene muchos Usuarios
        /// </summary>
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
