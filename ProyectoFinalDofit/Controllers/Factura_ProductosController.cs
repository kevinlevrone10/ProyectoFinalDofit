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
        public ActionResult Create()
        {
            ViewBag.Articulo_Id = new SelectList(db.Articulos, "Articulo_Id", "Descripcion");
            ViewBag.Factura_Id = new SelectList(db.Facturas, "Factura_Id", "Factura_Id");
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart( int Cantidad,int costo,string descripcion,int factura ,int Articulo_Id)
        {
            // Obtiene el carrito de la sesión (o crea uno nuevo si no existe)
            var cart = Session["cart"] as List<Factura_Productos> ?? new List<Factura_Productos>();

            // Agrega el producto al carrito
            cart.Add(new Factura_Productos { Cantidad = Cantidad , Costo_Unitario=costo, Factura_Id =factura ,Articulo_Id = Articulo_Id});

            // Guarda el carrito en la sesión
            Session["cart"] = cart;

            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<Factura_Productos> factura_Productos)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in factura_Productos)
                {
                    // Obtiene el artículo correspondiente
                    var articulo = db.Articulos.Find(item.Articulo_Id);

                    // Verifica si el artículo existe
                    if (articulo != null)
                    {
                        // Determina si es una entrada o salida
                        bool esEntrada = db.Facturas.Find(item.Factura_Id).Tipo_Movimientos.Salida_Entrada;

                        if (!esEntrada)
                        {
                            // Verifica si hay suficientes existencias para una salida
                            if (articulo.Cantidad < item.Cantidad)
                            {
                                // Si no hay suficientes existencias, redirige a una página de error o muestra un mensaje
                                ModelState.AddModelError("Cantidad", "No hay suficientes existencias para realizar la venta.");
                                ViewBag.Articulo_Id = new SelectList(db.Articulos, "Articulo_Id", "Codigo", item.Articulo_Id);
                                ViewBag.Factura_Id = new SelectList(db.Facturas, "Factura_Id", "Factura_Id", item.Factura_Id);
                                return View(factura_Productos);  // Devuelve la lista completa de productos
                            }
                        }

                        // Guarda la venta en Factura_Productos
                        db.Factura_Productos.Add(item);
                        db.SaveChanges();

                        // Actualiza las cantidades en la tabla Articulos
                        if (!esEntrada)
                        {
                            // Resta la cantidad vendida de las existencias actuales
                            articulo.Cantidad -= item.Cantidad;

                            // Verifica si el stock está llegando a cero
                            if (articulo.Cantidad <= 0)
                            {
                                // Puedes agregar aquí la lógica para mostrar una alerta, enviar un correo electrónico, etc.
                                // En este ejemplo, solo se establecerá una propiedad en el ViewBag para mostrar una alerta.
                                ViewBag.StockVacio = true;
                            }
                        }
                        else
                        {
                            // Suma la cantidad vendida a las existencias actuales
                            articulo.Cantidad += item.Cantidad;
                        }

                        // Guarda los cambios en la base de datos
                        db.SaveChanges();
                    }
                    else
                    {
                        // Manejo adicional si el artículo no existe
                        ModelState.AddModelError("Articulo_Id", "El artículo no existe.");
                    }
                }
            }

            // Si el modelo no es válido, vuelve a mostrar la vista de creación
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
            ViewBag.Articulo_Id = new SelectList(db.Articulos, "Articulo_Id", "Descripcion");
            ViewBag.Factura_Id = new SelectList(db.Facturas, "Factura_Id", "Factura_Id", factura_Productos.Factura_Id);
            return View(factura_Productos);
        }

     
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
