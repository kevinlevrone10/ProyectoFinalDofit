using ProyectoFinalDofit.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProyectoFinalDofit.Controllers
{
    public class VisitasController : Controller
    {
        private GimnasiofitEntities db = new GimnasiofitEntities();

        // GET: Visitas
        public ActionResult Index()
        {
            var visitas = db.Visitas.Include(v => v.Suscripciones).Include(v => v.Trabajadores);
            return View(visitas.ToList());
        }

        // GET: Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitas visitas = db.Visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            return View(visitas);
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            ViewBag.Suscripcion_Id = new SelectList(db.Suscripciones, "Suscripcion_Id", "Costo");
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo");
            return View();
        }

        // POST: Visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Visita_Id,Fecha,Suscripcion_Id,Trabajador_Id")] Visitas visitas)
        {
            if (ModelState.IsValid)
            {
                db.Visitas.Add(visitas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Suscripcion_Id = new SelectList(db.Suscripciones, "Suscripcion_Id", "Costo", visitas.Suscripcion_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", visitas.Trabajador_Id);
            return View(visitas);
        }

        // GET: Visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitas visitas = db.Visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Suscripcion_Id = new SelectList(db.Suscripciones, "Suscripcion_Id", "Costo", visitas.Suscripcion_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", visitas.Trabajador_Id);
            return View(visitas);
        }

        // POST: Visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Visita_Id,Fecha,Suscripcion_Id,Trabajador_Id")] Visitas visitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Suscripcion_Id = new SelectList(db.Suscripciones, "Suscripcion_Id", "Costo", visitas.Suscripcion_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", visitas.Trabajador_Id);
            return View(visitas);
        }

        // GET: Visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitas visitas = db.Visitas.Find(id);
            if (visitas == null)
            {
                return HttpNotFound();
            }
            return View(visitas);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visitas visitas = db.Visitas.Find(id);
            db.Visitas.Remove(visitas);
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
