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
    public class TrabajadoresController : Controller
    {
        private GimnasiofitEntities db = new GimnasiofitEntities();

        // GET: Trabajadores
        public ActionResult Index()
        {
            var trabajadores = db.Trabajadores.Include(t => t.Turnos);
            return View(trabajadores.ToList());
        }

        // GET: Trabajadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // GET: Trabajadores/Create
        public ActionResult Create()
        {
            ViewBag.Turno_Id = new SelectList(db.Turnos, "Turno_Id", "Descripcion");
            return View();
        }

        // POST: Trabajadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Trabajador_Id,Codigo,Nombre,Apellido,Telefono,Activo,Turno_Id")] Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Trabajadores.Add(trabajadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Turno_Id = new SelectList(db.Turnos, "Turno_Id", "Descripcion", trabajadores.Turno_Id);
            return View(trabajadores);
        }

        // GET: Trabajadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.Turno_Id = new SelectList(db.Turnos, "Turno_Id", "Descripcion", trabajadores.Turno_Id);
            return View(trabajadores);
        }

        // POST: Trabajadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Trabajador_Id,Codigo,Nombre,Apellido,Telefono,Activo,Turno_Id")] Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Turno_Id = new SelectList(db.Turnos, "Turno_Id", "Descripcion", trabajadores.Turno_Id);
            return View(trabajadores);
        }

        // GET: Trabajadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajadores.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajadores trabajadores = db.Trabajadores.Find(id);
            db.Trabajadores.Remove(trabajadores);
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
