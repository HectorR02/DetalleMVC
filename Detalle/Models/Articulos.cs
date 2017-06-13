using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Detalle.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int Existencia { get; set; }
    }
}