using Detalle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Detalle.DAL
{
    public class DetalleDb : DbContext
    {
        public DetalleDb() : base("ConnStr")
        {

        }

        public DbSet<Cotizaciones> Cotizacion { get; set; }

        public DbSet<CotizacionDetalles> DetalleCotizacion { get; set; }

        public DbSet<Articulos> Articulo { get; set; }

        public DbSet<Servicios> Servicio { get; set; }
    }
}