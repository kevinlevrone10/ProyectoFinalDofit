using Microsoft.AspNet.Identity;
using System.Web.Mvc;




namespace ProyectoFinalDofit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Obtener el nombre de usuario si está autenticado
            ViewBag.UserName = User.Identity.IsAuthenticated ? User.Identity.GetUserName() : null;

            return View();
        }

        public ActionResult Logout()
        {
            // Realizar las operaciones de cierre de sesión aquí

            // Redirigir al usuario a la página de inicio de sesión
            return RedirectToAction("Login", "Account");
        }




    }
}