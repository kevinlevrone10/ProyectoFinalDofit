using ProyectoFinalDofit.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProyectoFinalDofit.Controllers
{
    public class FacturasController : Controller
    {
        private GimnasiofitEntities1 db = new GimnasiofitEntities1();

        // GET: Facturas
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Proveedores).Include(f => f.Tipo_Movimientos).Include(f => f.Trabajadores);
            return View(facturas.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.Proveedor_Id = new SelectList(db.Proveedores, "Proveedor_Id", "Nombre");
            ViewBag.Tipo_Movimiento_Id = new SelectList(db.Tipo_Movimientos, "Tipo_Movimiento_Id", "Descripcion");
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Factura_Id,Numero_Factura,Fecha,Trabajador_Id,Proveedor_Id,Tipo_Movimiento_Id")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(facturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Proveedor_Id = new SelectList(db.Proveedores, "Proveedor_Id", "Nombre", facturas.Proveedor_Id);
            ViewBag.Tipo_Movimiento_Id = new SelectList(db.Tipo_Movimientos, "Tipo_Movimiento_Id", "Descripcion", facturas.Tipo_Movimiento_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", facturas.Trabajador_Id);
            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Proveedor_Id = new SelectList(db.Proveedores, "Proveedor_Id", "Nombre", facturas.Proveedor_Id);
            ViewBag.Tipo_Movimiento_Id = new SelectList(db.Tipo_Movimientos, "Tipo_Movimiento_Id", "Descripcion", facturas.Tipo_Movimiento_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", facturas.Trabajador_Id);
            return View(facturas);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Factura_Id,Numero_Factura,Fecha,Trabajador_Id,Proveedor_Id,Tipo_Movimiento_Id")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Proveedor_Id = new SelectList(db.Proveedores, "Proveedor_Id", "Nombre", facturas.Proveedor_Id);
            ViewBag.Tipo_Movimiento_Id = new SelectList(db.Tipo_Movimientos, "Tipo_Movimiento_Id", "Descripcion", facturas.Tipo_Movimiento_Id);
            ViewBag.Trabajador_Id = new SelectList(db.Trabajadores, "Trabajador_Id", "Codigo", facturas.Trabajador_Id);
            return View(facturas);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facturas facturas = db.Facturas.Find(id);
            db.Facturas.Remove(facturas);
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
