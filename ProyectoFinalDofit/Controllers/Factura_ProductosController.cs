using ProyectoFinalDofit.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProyectoFinalDofit.Controllers
{
    public class Factura_ProductosController : Controller
    {
        private GimnasiofitEntities1 db = new GimnasiofitEntities1();

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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Factura_Producto_Id,Cantidad,Costo_Unitario,Factura_Id,Articulo_Id")] Factura_Productos factura_Productos)
        {
            if (ModelState.IsValid)
            {
                // Obtiene el artículo correspondiente
                var articulo = db.Articulos.Find(factura_Productos.Articulo_Id);

                // Verifica si el artículo existe
                if (articulo != null)
                {
                    // Determina si es una entrada o salida
                    bool esEntrada = db.Facturas.Find(factura_Productos.Factura_Id).Tipo_Movimientos.Salida_Entrada;

                    if (!esEntrada)
                    {
                        // Verifica si hay suficientes existencias para una salida
                        if (articulo.Cantidad < factura_Productos.Cantidad)
                        {
                            // Si no hay suficientes existencias, redirige a una página de error o muestra un mensaje
                            ModelState.AddModelError("Cantidad", "No hay suficientes existencias para realizar la venta.");
                            ViewBag.Articulo_Id = new SelectList(db.Articulos, "Articulo_Id", "Codigo", factura_Productos.Articulo_Id);
                            ViewBag.Factura_Id = new SelectList(db.Facturas, "Factura_Id", "Factura_Id", factura_Productos.Factura_Id);
                            return View(factura_Productos);
                        }
                    }

                    // Guarda la venta en Factura_Productos
                    db.Factura_Productos.Add(factura_Productos);
                    db.SaveChanges();

                    // Actualiza las cantidades en la tabla Articulos
                    if (!esEntrada)
                    {
                        // Resta la cantidad vendida de las existencias actuales
                        articulo.Cantidad -= factura_Productos.Cantidad;

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
                        articulo.Cantidad += factura_Productos.Cantidad;
                    }

                    // Guarda los cambios en la base de datos
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    // Manejo adicional si el artículo no existe
                    ModelState.AddModelError("Articulo_Id", "El artículo no existe.");
                }
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
