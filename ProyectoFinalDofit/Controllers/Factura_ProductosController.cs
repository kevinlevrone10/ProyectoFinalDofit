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
    public class Factura_ProductosController : Controller
    {
        private GimnasiofitEntities db = new GimnasiofitEntities();

        // GET: Factura_Productos
        public ActionResult Index()
        {
            var factura_Productos = db.Factura_Productos.Include(f => f.Articulos).Include(f => f.Facturas);
            return View(factura_Productos.ToList());
        }

        // GET: Factura_Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_Productos factura_Productos = db.Factura_Productos.Find(id);
            if (factura_Productos == null)
            {
                return HttpNotFound();
            }
            return View(factura_Productos);
        }

        // GET: Factura_Productos/Create
        public ActionResult Create()
        {
            ViewBag.Articulo_Id = new SelectList(db.Articulos, "Articulo_Id", "Codigo");
            ViewBag.Factura_Id = new SelectList(db.Facturas, "Factura_Id", "Factura_Id");
            return View();
        }

        // POST: Factura_Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Factura_Producto_Id,Cantidad,Costo_Unitario,Factura_Id,Articulo_Id")] Factura_Productos factura_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Factura_Productos.Add(factura_Productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Articulo_Id = new SelectList(db.Articulos, "Articulo_Id", "Codigo", factura_Productos.Articulo_Id);
            ViewBag.Factura_Id = new SelectList(db.Facturas, "Factura_Id", "Factura_Id", factura_Productos.Factura_Id);
            return View(factura_Productos);
        }

        // GET: Factura_Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_Productos factura_Productos = db.Factura_Productos.Find(id);
            if (factura_Productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Articulo_Id = new SelectList(db.Articulos, "Articulo_Id", "Codigo", factura_Productos.Articulo_Id);
            ViewBag.Factura_Id = new SelectList(db.Facturas, "Factura_Id", "Factura_Id", factura_Productos.Factura_Id);
            return View(factura_Productos);
        }

        // POST: Factura_Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Factura_Producto_Id,Cantidad,Costo_Unitario,Factura_Id,Articulo_Id")] Factura_Productos factura_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura_Productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Articulo_Id = new SelectList(db.Articulos, "Articulo_Id", "Codigo", factura_Productos.Articulo_Id);
            ViewBag.Factura_Id = new SelectList(db.Facturas, "Factura_Id", "Factura_Id", factura_Productos.Factura_Id);
            return View(factura_Productos);
        }

        // GET: Factura_Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_Productos factura_Productos = db.Factura_Productos.Find(id);
            if (factura_Productos == null)
            {
                return HttpNotFound();
            }
            return View(factura_Productos);
        }

        // POST: Factura_Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura_Productos factura_Productos = db.Factura_Productos.Find(id);
            db.Factura_Productos.Remove(factura_Productos);
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
