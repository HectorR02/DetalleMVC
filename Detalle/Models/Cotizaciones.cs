using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Detalle.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Cliente { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.Currency)]
        public double Monto { get; set; }

        //public ICollection<CotizacionDetalles> Detalle { get; set; }

        public Cotizaciones()
        {
            //Detalle = new HashSet<CotizacionDetalles>();
        }
    }
}