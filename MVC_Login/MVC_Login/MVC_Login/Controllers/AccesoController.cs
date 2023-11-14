using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using MVC_Login.Models;

namespace MVC_Login.Controllers
{
    public class AccesoController : Controller
    {
        private DarwinGodEntities10 db = new DarwinGodEntities10();


        [HttpGet]
        public ActionResult Index()
        {
          

            return View("~/Views/Acceso/Index.cshtml");
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            var result = db.ObtenerUsuarioPorCorreoYPassword(email, password).FirstOrDefault();     
            List<ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente_Result> datosParaElIndex = db.ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente(email).ToList();
            Session["datosParaElIndex"] = datosParaElIndex;
        int ResultadoRolDeUsuario = Convert.ToInt32(result.RolUsuario);

            if (ResultadoRolDeUsuario == 1) //administradores
            {
                ObtenerUsuarioPorCorreoYPassword_Result Sesion = result;
                Session["Sesion1"] = Sesion;
                Session["datosParaElIndex"] = datosParaElIndex;
                return View("~/Views/Home/Index.cshtml",datosParaElIndex);

            }
            else if (ResultadoRolDeUsuario == 2) //veteranos
            {
                ObtenerUsuarioPorCorreoYPassword_Result Sesion = result;
                Session["Sesion2"] = Sesion;
        

                return View("~/Views/Home/Index.cshtml", datosParaElIndex);
            }
            else
            {
                ModelState.AddModelError("", "Inicio de sesión fallido. Por favor, verifica tu correo electrónico y contraseña.");

                return View("~/Views/Acceso/Index.cshtml"); 
            }
        }
        public ActionResult LogOut()
        {
            Session["Sesion1"] = null;
            Session["Sesion2"] = null;

            return View("~/Views/Acceso/Index.cshtml");
        }





    }
}