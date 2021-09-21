using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorHotelJJCliente.Models;
using GestorHotelJJCliente.Models.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GestorHotelJJCliente.Controllers
{
    public class UsuarioController : Controller
    {
        public IConfiguration Configuration { get; }
        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public IActionResult MuestraLoginUsuario()
        {

            //Se limpian las variables en session
            HttpContext.Session.SetString("UsuarioLogin", "");
            HttpContext.Session.SetString("UsuarioPermiso", "");
            return View("/Views/Administrador/Home/IniciarSesionAdminView.cshtml");
        }


        public IActionResult IndexAdministrador()
        {
            //Se limpian las variables en session
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("~/Views/Administrador/Home/LoginUsuario.cshtml");
        }


        //public IActionResult LoginUsuario()
        //{
        //    //Se limpian las variables en session

        //    return View("~/Views/Administrador/Home/IniciarSesionAdminView.cshtml");
        //}



        public IActionResult LoginUsuario()
        {

           //System.Diagnostics.Debug.WriteLine("-------------------------------------*" + HttpContext.Session.GetString("UsuarioPermiso"));

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("~/Views/Administrador/Home/LoginUsuario.cshtml");

        } // Login Usuar


        [HttpPost]
        public IActionResult LoginUsuario(UsuarioModel usuario)
        {

            //Se crea un objeto usuario y se le asigna un valor desde la base de datos
            UsuarioModel usuarioModel = new UsuarioModel();

            BusinessUsuario bussinesUsuario = new BusinessUsuario(Configuration);
            usuarioModel = bussinesUsuario.LoginUsuario(usuario);

            //Si es diferente de null es que existe por lo tanto pasa a la siguiente vista, en caso contrario regresa al login con un mensaje de error
            if (usuarioModel != null)
            {

                HttpContext.Session.SetString("UsuarioLogin", usuarioModel.TC_Usuario);
                HttpContext.Session.SetString("UsuarioPermiso", usuarioModel.TN_Id_Permiso.ToString());
                //El ViewBag.PermisoUsuario se utiliza controlar el inicio de session de un usuario y su respectivos permisos
                ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

                return View("~/Views/Administrador/Home/LoginUsuario.cshtml");


            }
            else
            {
                String ERROR = " Error en las credenciales";
                ViewBag.ERROR = ERROR;
                return View("/Views/Administrador/Home/IniciarSesionAdminView.cshtml");
            }

        } // Login Usuario

        public IActionResult LogOutUsuario()
        {
            HttpContext.Session.SetString("UsuarioPermiso", "");
            HttpContext.Session.SetString("UsuarioLogin", "");
            return View("/Views/Administrador/Home/IniciarSesionAdminView.cshtml");
        }

    }
            
}
