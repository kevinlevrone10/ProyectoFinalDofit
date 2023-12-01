using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDofit.Models;

namespace ProyectoFinalDofit.Controllers
{
    public class SuscripcionesController : Controller
    {
        private GimnasiofitEntities1 db = new GimnasiofitEntities1();

        // GET: Suscripciones
        public ActionResult Index()
        {
            var suscripciones = db.Suscripciones.Include(s => s.Clientes).Include(s => s.Plan_Clientes).Include(s => s.Trabajadores);
            return View(suscripciones.ToList());
        }

        // GET: Suscripciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripciones suscripciones = db.Suscripciones.Find(id);
            if (suscripciones == null)
            {
                return HttpNotFound();
            }
            return View(suscripciones);
        }

        // GET: Suscripciones/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_Id = new SelectList(db.Clientes, "Cliente_Id", "Nombre");
            ViewBag.Plan_Clientes_Id = new SelectList(db.Plan_Clientes, "Plan_Clientes_Id", "Descripcion");
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo");
            return View();
        }

        // POST: Suscripciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Suscripcion_Id,Numero_Suscripcion,Fecha_Inicio,Fecha_Finalizacion,Costo,Descuento,Activo,Cliente_Id,Plan_Clientes_Id,Trabajador_Id,New_Suscripcion_Id")] Suscripciones suscripciones)
        {
            if (ModelState.IsValid)
            {
                db.Suscripciones.Add(suscripciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_Id = new SelectList(db.Clientes, "Cliente_Id", "Nombre", suscripciones.Cliente_Id);
            ViewBag.Plan_Clientes_Id = new SelectList(db.Plan_Clientes, "Plan_Clientes_Id", "Descripcion", suscripciones.Plan_Clientes_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", suscripciones.Trabajador_Id);
            return View(suscripciones);
        }

        // GET: Suscripciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripciones suscripciones = db.Suscripciones.Find(id);
            if (suscripciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_Id = new SelectList(db.Clientes, "Cliente_Id", "Nombre", suscripciones.Cliente_Id);
            ViewBag.Plan_Clientes_Id = new SelectList(db.Plan_Clientes, "Plan_Clientes_Id", "Descripcion", suscripciones.Plan_Clientes_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", suscripciones.Trabajador_Id);
            return View(suscripciones);
        }

        // POST: Suscripciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Suscripcion_Id,Numero_Suscripcion,Fecha_Inicio,Fecha_Finalizacion,Costo,Descuento,Activo,Cliente_Id,Plan_Clientes_Id,Trabajador_Id,New_Suscripcion_Id")] Suscripciones suscripciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suscripciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_Id = new SelectList(db.Clientes, "Cliente_Id", "Nombre", suscripciones.Cliente_Id);
            ViewBag.Plan_Clientes_Id = new SelectList(db.Plan_Clientes, "Plan_Clientes_Id", "Descripcion", suscripciones.Plan_Clientes_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", suscripciones.Trabajador_Id);
            return View(suscripciones);
        }

        // GET: Suscripciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripciones suscripciones = db.Suscripciones.Find(id);
            if (suscripciones == null)
            {
                return HttpNotFound();
            }
            return View(suscripciones);
        }

        // POST: Suscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suscripciones suscripciones = db.Suscripciones.Find(id);
            db.Suscripciones.Remove(suscripciones);
            db.SaveChanges();
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
