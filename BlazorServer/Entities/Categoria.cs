using System;
using System.Collections.Generic;

namespace BlazorServer.Entities
{
    public class Categoria
    {
        //public Categoria()
        //{
        //    Productos = new HashSet<Producto>();
        //}

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        /// <summary>
        /// Una Categoria tiene muchos productos
        /// </summary>
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
