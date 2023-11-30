using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;




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