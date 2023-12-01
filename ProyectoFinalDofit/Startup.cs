using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using ProyectoFinalDofit.Models;

[assembly: OwinStartupAttribute(typeof(ProyectoFinalDofit.Startup))]
namespace ProyectoFinalDofit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRoles();
        }
        private void CrearRoles()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Crear el rol "Admin" si no existe
            if (!roleManager.RoleExists("Admin"))
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "Admin"
                };

                roleManager.Create(roleAdmin);

                var userAdmin = new ApplicationUser
                {
                    UserName = "kevin.gutierrez20043330@estu.unan.edu.ni",
                    Email = "kevin.gutierrez20043330@estu.unan.edu.ni"
                };

                string pwdAdmin = "@Unan2020";

                var resultAdmin = userManager.Create(userAdmin, pwdAdmin);

                if (resultAdmin.Succeeded)
                {
                    userManager.AddToRole(userAdmin.Id, "Admin");
                }
            }

            // Crear el rol "TrabajadorDia" si no existe
            if (!roleManager.RoleExists("TrabajadorDia"))
            {
                var roleTrabajadorDia = new IdentityRole
                {
                    Name = "TrabajadorDia"
                };

                roleManager.Create(roleTrabajadorDia);

                var userTrabajadorDia = new ApplicationUser
                {
                    UserName = "kevin.gutierrez20043331@estu.unan.edu.ni",
                    Email = "kevin.gutierrez20043331@estu.unan.edu.ni"
                };

                string pwdTrabajadorDia = "@Unan2020";

                var resultTrabajadorDia = userManager.Create(userTrabajadorDia, pwdTrabajadorDia);

                if (resultTrabajadorDia.Succeeded)
                {
                    userManager.AddToRole(userTrabajadorDia.Id, "TrabajadorDia");
                }
            }

            // Crear el rol "TrabajadorTarde" si no existe
            if (!roleManager.RoleExists("TrabajadorTarde"))
            {
                var roleTrabajadorTarde = new IdentityRole
                {
                    Name = "TrabajadorTarde"
                };

                roleManager.Create(roleTrabajadorTarde);

                var userTrabajadorTarde = new ApplicationUser
                {
                    UserName = "kevin.gutierrez20043333@estu.unan.edu.ni",
                    Email = "kevin.gutierrez20043333@estu.unan.edu.ni"
                };

                string pwdTrabajadorTarde = "@Unan2020";

                var resultTrabajadorTarde = userManager.Create(userTrabajadorTarde, pwdTrabajadorTarde);

                if (resultTrabajadorTarde.Succeeded)
                {
                    userManager.AddToRole(userTrabajadorTarde.Id, "TrabajadorTarde");
                }
            }
        }


    }
}

