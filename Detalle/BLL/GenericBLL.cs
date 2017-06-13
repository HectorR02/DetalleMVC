using Detalle.DAL;
using Detalle.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Detalle.BLL
{
    public class GenericBLL
    {
        public static int Identity(string tabla)
        {
            int identity = 0;
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DetalleDb.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conexion = new SqlConnection(con))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('"+tabla+"')", conexion);
                    identity = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return identity;
        }

        public static List<Articulos> ListarArticulos()
        {
            List<Articulos> listado = null;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    listado = conexion.Articulo.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static List<Servicios> ListarServicios()
        {
            List<Servicios> listado = null;
            using (var conexion = new DetalleDb())
            {
                try
                {
                    listado = conexion.Servicio.ToList();
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