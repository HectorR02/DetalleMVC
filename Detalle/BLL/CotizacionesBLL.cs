using Detalle.DAL;
using Detalle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Detalle.BLL
{
    public class CotizacionesBLL
    {
        public static bool Guardar(Cotizaciones cotizacion)
        {
            bool resultado = false;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    conexion.Cotizacion.Add(cotizacion);
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
        public static Cotizaciones Buscar(int? cotizacionId)
        {
            Cotizaciones cotizacion = null;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    cotizacion = conexion.Cotizacion.Find(cotizacionId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cotizacion;
        }
        public static bool Modificar(Cotizaciones cotizacion)
        {
            bool resultado = false;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    conexion.Entry(cotizacion).State = EntityState.Modified;
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
        public static bool Eliminar(Cotizaciones cotizacion)
        {
            bool resultado = false;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    conexion.Entry(cotizacion).State = EntityState.Deleted;
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
        public static List<Cotizaciones> Listar()
        {
            List<Cotizaciones> listado = null;
            using (var conexion = new DetalleDb())
            {
                try
                {
                   listado = conexion.Cotizacion.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }        
    }
}