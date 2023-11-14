using MVC_Login.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Linq;
using System;
using System.Data.Entity;

namespace MVC_Login.Controllers
{



    public class HomeController : Controller
    {
        DarwinGodEntities10 db = new DarwinGodEntities10();

        [HttpGet]
        /*Inicio de las funcionalidades para los usuarios normales*/

        public ActionResult Index()
        {
            // Obtén los datos de la sesión directamente
            List<ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente_Result> datosParaElIndex = HttpContext.Session["datosParaElIndex"] as List<ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente_Result>;

            if (datosParaElIndex == null)
            {
                TempData["Error"] = "No hay datos disponibles.";
                return RedirectToAction("Error", "Home");
            }

            // Pasa los datos directamente a la vista
            return View("~/Views/Home/Index.cshtml", datosParaElIndex);
        }



        [HttpGet]
        public ActionResult TusBeneficios()
        {
            List<ObtenerDonativosPorCorreoTodosLosBeneficios_Result> listaDeBeneficios;

            using (DarwinGodEntities10 db = new DarwinGodEntities10())
            {
                var sesion1 = Session["sesion1"] as ObtenerUsuarioPorCorreoYPassword_Result;
                var sesion2 = Session["sesion2"] as ObtenerUsuarioPorCorreoYPassword_Result;

                var correoUsuario = sesion1?.Correo ?? sesion2?.Correo;

                if (correoUsuario != null)
                {
                    // Obtener la lista de beneficios solo si correoUsuario no es null
                    listaDeBeneficios = db.ObtenerDonativosPorCorreoTodosLosBeneficios(correoUsuario).ToList();
                }
                else
                {
                    // Manejar el caso en el que ambos objetos de sesión son null o no se encontró un correo válido
                    // Puedes retornar una vista de error o realizar alguna otra acción apropiada
                    // En este ejemplo, estoy inicializando la lista como vacía
                    listaDeBeneficios = new List<ObtenerDonativosPorCorreoTodosLosBeneficios_Result>();
                }
            }

            // Verificar si la lista de beneficios está vacía o nula
            if (listaDeBeneficios == null || listaDeBeneficios.Count == 0)
            {
                // Manejar el caso en el que el usuario no tiene beneficios en la base de datos
                // Puedes retornar una vista de error o realizar alguna otra acción apropiada
                // En este ejemplo, estoy agregando un mensaje a la vista
                ViewBag.MensajeError = "El usuario no tiene beneficios en la base de datos.";
            }

            // Puedes pasar la listaDeBeneficios como modelo a tu vista
            return View("~/Views/Home/TusBeneficios.cshtml", listaDeBeneficios);
        }


        [HttpGet]
        public ActionResult PanelDeControlGet()
        {
            ViewBag.Message = "Your contact page.";

            return View("~/Views/Home/PanelDeControl.cshtml");
        }
        [HttpGet]
        public ActionResult RealizarDonativoAlimentosGet()
        {
            return View("~/Views/Home/RealizarDonativoAlimento.cshtml");
        }

        [HttpGet]
        public ActionResult RealizarDonativoProductosGet()
        {
            return View("~/Views/Home/RealizarDonativoProducto.cshtml");
        }

        [HttpGet]
        public ActionResult RealizarDonativoDineroGet()
        {
            return View("~/Views/Home/RealizarDonativoDinero.cshtml");
        }


        [HttpPost]
        public ActionResult RealizarDonativoProductosPost([Bind(Include = "ID,Donativo,correocomo_fk,fecha_donativo")] DonativosProductosPersonale donativoProducto)
        {
            donativoProducto.fecha_donativo = DateTime.Now;
            if (ModelState.IsValid && db.Usuarios.Any(d => d.correo == donativoProducto.correocomo_fk))
            {
                db.DonativosProductosPersonales.Add(donativoProducto);
                db.SaveChanges();
                return View("~/Views/Home/PanelDeControl.cshtml");
            }

            ViewBag.correocomo_fk = "Esto no sirve";
            return View("~/Views/Home/RealizarDonativoProducto.cshtml");
        }

        [HttpPost]
        public ActionResult RealizarDonativoDineroPost([Bind(Include = "ID,Donativo,correocomo_fk,fecha_donativo")] DonativosDinero dineroDonativo)
        {
            dineroDonativo.fecha_donativo = DateTime.Now;
            dineroDonativo.Donativo = Convert.ToDecimal(dineroDonativo.Donativo);
            dineroDonativo.correocomo_fk = Convert.ToString(dineroDonativo.correocomo_fk);
            if (ModelState.IsValid && db.Usuarios.Any(d => d.correo == dineroDonativo.correocomo_fk))
            {
                db.DonativosDineroes.Add(dineroDonativo);
                db.SaveChanges();
                return View("~/Views/Home/PanelDeControl.cshtml");
            }

            ViewBag.correocomo_fk = "Esto no sirve";
            return View("~/Views/Home/RealizarDonativoDinero.cshtml");
        }


        [HttpPost]
        public ActionResult RealizarDonativoAlimentosPost([Bind(Include = "ID,Donativo,correocomo_fk,fecha_donativo")] DonativosAlimentacion donativosAlimentacion)
        {
            donativosAlimentacion.fecha_donativo = DateTime.Now;
            if (ModelState.IsValid && db.Usuarios.Any(d => d.correo == donativosAlimentacion.correocomo_fk))
            {


                db.DonativosAlimentacions.Add(donativosAlimentacion);
                db.SaveChanges();
                return View("~/Views/Home/PanelDeControl.cshtml");
            }

            ViewBag.correocomo_fk = "Esto no sirve";
            return View("~/Views/Home/RealizarDonativoAlimento.cshtml");

        }



      
        [HttpGet]
        public ActionResult VerTodosLosDonativosDeUnUsuarioGet()
        {
            return View("~/Views/Home/Administradores/VerTodosLosDonativosDeUnUsuario.cshtml");
        }



        public ActionResult VerTodosLosDonativosDeUnUsuarioPost(string correo)
        {
            List<ObtenerDonativosPorCorreoTodosLosBeneficios_Result> Buscador;

            using (DarwinGodEntities10 db = new DarwinGodEntities10())
            {
            

                if (correo != null)
                {
                    // Obtener la lista de beneficios solo si correoUsuario no es null
                    Buscador = db.ObtenerDonativosPorCorreoTodosLosBeneficios(correo).ToList();
                }
                else
                {
                    // Manejar el caso en el que ambos objetos de sesión son null o no se encontró un correo válido
                    // Puedes retornar una vista de error o realizar alguna otra acción apropiada
                    // En este ejemplo, estoy inicializando la lista como vacía
                    Buscador = new List<ObtenerDonativosPorCorreoTodosLosBeneficios_Result>();
                }
            }

            // Verificar si la lista de beneficios está vacía o nula
            if (Buscador == null || Buscador.Count == 0)
            {
                // Manejar el caso en el que el usuario no tiene beneficios en la base de datos
                // Puedes retornar una vista de error o realizar alguna otra acción apropiada
                // En este ejemplo, estoy agregando un mensaje a la vista
                ViewBag.MensajeError = "El usuario no tiene beneficios en la base de datos.";
            }

            // Puedes pasar la listaDeBeneficios como modelo a tu vista
            return View("~/Views/Home/Administradores/VerTodosLosDonativosDeUnUsuario.cshtml", Buscador);
        }


        /*Fin de las funcionalidades para los usuarios normales*/







        /*Funcionalidades de los administradores*/
        [HttpGet]
        public ActionResult IngresarUsuarioGet()
        {
            return View("~/Views/Home/Administradores/IngresarUsuario.cshtml");
        }
       
        public ActionResult BorrarUsuarioGet()
        {
            return View("~/Views/Home/Administradores/BorrarUsuario.cshtml");
        }



        /*Funcionalidades tryhard*/
        [HttpPost]
        [ValidateAntiForgeryToken] //Funciona
        public ActionResult IngresarUsuarioPost([Bind(Include = "correo,nombres,apellidos,password_usuario,direccion_residencia,estado_extranjero,RolUsuario_fk")] Usuario usuario)
        {
            // Verificar si el correo ya existe en la base de datos
            if (db.Usuarios.Any(u => u.correo == usuario.correo))
            {
                // El correo ya existe, mostrar un mensaje de error
                ViewBag.ErrorMessage = "No se puede ingresar este usuario. El correo ya está en el sistema.";
                return View("IngresarUsuario");
            }

            if (ModelState.IsValid)
            {
                // Set the foreign key to 2
                usuario.RolUsuario_fk = 2;

                // Add the modified usuario to the context
                db.Usuarios.Add(usuario);

                // Save changes to the database
                db.SaveChanges();

                // Redirect to the specified action
                return RedirectToAction("PanelDeControlGet");
            }

            // If the model state is not valid, return the view with the usuario and the available roles
            return View("~/Views/Home/Administradores/IngresarUsuario.cshtml");
        }


        [HttpPost]
        public ActionResult BorrarUsuarioPost(string correo) //Funciona
        {
            if (db.Usuarios.Any(u => u.correo == correo))
            {
                //Si encuentra un correo en la base de datos lo borra
                db.EliminarUsuarioYDonativos(correo);
                ViewBag.ErrorMessage = "";
                return View("~/Views/Home/Administradores/BorrarUsuario.cshtml");
            }
            ViewBag.ErrorMessage = "No se puede eliminar este usuario. Ya que el correo no existe en la base de datos";

            return View("~/Views/Home/Administradores/BorrarUsuario.cshtml");
        }


        [HttpGet] 
        public ActionResult ActualizarUsuarioGet() 
        {
            return View("~/Views/Home/Administradores/ActualizarUsuario.cshtml");

                }

       [HttpPost]
        public ActionResult ActualizarUsuarioPost(string correo, string nombres, string apellidos, string password_usuario, string direccion_residencia, Nullable<bool> estado_extranjero)
        {
            if (db.Usuarios.Any(u => u.correo == correo))
            {
                //Si encuentra un correo en la base de datos lo borra
                db.sp_ActualizarUsuario(correo,nombres,apellidos,password_usuario,direccion_residencia,estado_extranjero);
                ViewBag.ErrorMessage = "";
                return View("~/Views/Home/PanelDeControl.cshtml");
            }

            ViewBag.ErrorMessage = "Hubo un error el correo no existe en la base de datos, por lo que no se puede actualizar";
            return View("~/Views/Home/Administradores/ActualizarUsuario.cshtml");
        }

        


    }
}