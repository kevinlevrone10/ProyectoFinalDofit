﻿using System.Web.Optimization;

namespace ProyectoFinalDofit
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                       "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                     "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/uza/customStyles").Include(
    "~/Content/uza/asset/estilos/estilos.css",
    "~/Content/uza/asset/estilos/estilos.css"));

       bundles.Add(new ScriptBundle("~/Content/uza/customScript").Include("~/Content/uza/asset/js/app.js"));

       bundles.Add(new ScriptBundle("~/Content/src/customStyles").Include("~/Content/src/estilos/estiloslanding.css", "~/Content/src/estilos/normalize.css"));




        }
    }
}
