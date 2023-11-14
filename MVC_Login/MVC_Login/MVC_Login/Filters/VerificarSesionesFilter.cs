using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Login.Controllers;
using MVC_Login.Models;



    namespace MVC_Login.Filters
    {
           //Middleware
            public class VerificarSesionesFilter : ActionFilterAttribute
            {
                public override void OnActionExecuting(ActionExecutingContext filterContext)
                {
                // Comprobar si las sesiones no están disponibles
                var sesionUsuario = HttpContext.Current.Session["sesion1"] as ObtenerUsuarioPorCorreoYPassword_Result
                       ?? HttpContext.Current.Session["sesion2"] as ObtenerUsuarioPorCorreoYPassword_Result;



                if (sesionUsuario == null)
                {
                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Index");
                    }
                }
                else
                {
                    if (filterContext.Controller is AccesoController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("/Home/Index");
                    }
                }
                base.OnActionExecuting(filterContext);
                }
            }




      
}
