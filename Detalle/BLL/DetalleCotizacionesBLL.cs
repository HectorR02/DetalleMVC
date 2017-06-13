using Detalle.DAL;
using Detalle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Detalle.BLL
{
    public class DetalleCotizacionesBLL
    {
        public static bool Guardar(CotizacionDetalles detalle)
        {
            bool resultado = false;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    conexion.DetalleCotizacion.Add(detalle);
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static CotizacionDetalles Buscar(int? detalleCotizacionId)
        {
            CotizacionDetalles detalle = null;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    detalle = conexion.DetalleCotizacion.Find(detalleCotizacionId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return detalle;
        }
        public static bool Modificar(CotizacionDetalles detalle)
        {
            bool resultado = false;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    conexion.Entry(detalle).State = EntityState.Modified;
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Eliminar(CotizacionDetalles detalle)
        {
            bool resultado = false;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    conexion.Entry(detalle).State = EntityState.Deleted;
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static List<CotizacionDetalles> Listar()
        {
            List<CotizacionDetalles> listado = null;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    listado = conexion.DetalleCotizacion.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Guardar(List<CotizacionDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (CotizacionDetalles detail in detalles)
                {
                    resultado = Guardar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
        public static List<CotizacionDetalles> Listar(int? cotizacionId)
        {
            List<CotizacionDetalles> listado = null;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    listado = conexion.DetalleCotizacion.Where(d => d.CotizacionId == cotizacionId).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Eliminar(List<CotizacionDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (CotizacionDetalles detalle in detalles)
                {
                    var detail = Buscar(detalle.CotizacionDetalleId);
                    if (detail != null)
                    {
                        resultado = Eliminar(detail);
                    }
                    else
                        continue;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
        public static bool Modificar(List<CotizacionDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (CotizacionDetalles detalle in detalles)
                {
                    var detail = Buscar(detalle.CotizacionDetalleId);
                    if (detail != null)
                    {
                        resultado = Modificar(detalle);
                    }
                    else
                    {
                        resultado = Guardar(detalle);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
    }
}