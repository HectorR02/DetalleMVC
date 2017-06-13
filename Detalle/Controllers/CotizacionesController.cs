using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Detalle.DAL;
using Detalle.Models;

namespace Detalle.Controllers
{
    public class CotizacionesController : Controller
    {
        private DetalleDb db = new DetalleDb();

        // GET: Cotizaciones
        public ActionResult Index()
        {
            return View(BLL.CotizacionesBLL.Listar());
        }

        // GET: Cotizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = BLL.CotizacionesBLL.Buscar(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Create
        public ActionResult Create()
        {
            ViewBag.Detail = new List<CotizacionDetalles>();
            return View();
        }

        // POST: Cotizaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionId,Cliente,Fecha,Monto")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                BLL.CotizacionesBLL.Guardar(cotizaciones);
                return RedirectToAction("Index");
            }

            return View(cotizaciones);
        }

        [HttpPost]
        public JsonResult Guardar(Cotizaciones cotizacion)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                cotizacion.Fecha = DateTime.Now;
                if (BLL.CotizacionesBLL.Guardar(cotizacion))
                {
                    id = cotizacion.CotizacionId;
                }
            }
            else
            {
                id = -1;
            }
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Buscar(int? id)
        {
            Cotizaciones cotizacion = BLL.CotizacionesBLL.Buscar(id);
            if (cotizacion != null)
            {
                return Json(cotizacion, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult IdentityNetx(string Table)
        {
            int idNetx = BLL.GenericBLL.Identity(Table);

            if (idNetx > 1 || BLL.CotizacionesBLL.Listar().Count > 0)
                ++idNetx;

            return Json(idNetx, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Modificar(Cotizaciones cotizacion)
        {
            var result = 0;
            if (ModelState.IsValid)
            {
                if (BLL.CotizacionesBLL.Modificar(cotizacion))
                {
                    result = 1;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Eliminar(Cotizaciones cotizacion)
        {
            int id = cotizacion.CotizacionId;
            var cot = BLL.CotizacionesBLL.Buscar(id);
            var result = 0;
            if (cot != null)
            {
                if (BLL.CotizacionesBLL.Eliminar(cot))
                {
                    if (BLL.DetalleCotizacionesBLL.Eliminar(BLL.DetalleCotizacionesBLL.Listar(id)))
                    {
                        result = 1;
                    }
                }
                else
                    result = 0;
            }
            else
                result = 0;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Cotizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = BLL.CotizacionesBLL.Buscar(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionId,Cliente,Fecha,Monto")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                BLL.CotizacionesBLL.Modificar(cotizaciones);
                return RedirectToAction("Index");
            }
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = BLL.CotizacionesBLL.Buscar(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizaciones cotizaciones = BLL.CotizacionesBLL.Buscar(id);
            BLL.CotizacionesBLL.Eliminar(cotizaciones);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
