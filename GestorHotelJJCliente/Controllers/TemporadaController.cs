using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorHotelJJCliente.Models.Administrador;
using GestorHotelJJCliente.Models.Administrador.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GestorHotelJJCliente.Controllers
{
    public class TemporadaController : Controller
    {
        public IConfiguration Configuration { get; }

        public TemporadaController(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public IActionResult verCRUDTemporada()
        {
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("/Views/Administrador/VistaTemporadas/CRUDTemporadaView.cshtml");

        }

        public IActionResult CrearTemporada(TemporadaAdminModel tempModel)
        {

            //Se crea un objeto temporada y se le asigna un valor desde la base de datos

            int valido = 0;

            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(Configuration);
            valido = temporadaBusiness.CrearTemporada(tempModel);

            //Si es diferente de null es que existe por lo tanto pasa a la siguiente vista, en caso contrario regresa al login con un mensaje de error
            if (valido  != 0)
            {

                //El ViewBag.PermisoUsuario se utiliza controlar el inicio de session de un usuario y su respectivos permisos
                ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                ViewBag.valido = "Éxito al registrar temporada.";
                return View("/Views/Administrador/VistaTemporadas/CRUDTemporadaView.cshtml");


            }
            else
            {
                ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                String ERROR = "Ya existe una temporada dentro del rango de fechas";
                ViewBag.valido = ERROR;

                return View("/Views/Administrador/VistaTemporadas/CRUDTemporadaView.cshtml");
            }

        }


        public IActionResult VerModificarEliminarTemporada()
        {

            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(Configuration);
            List<TemporadaAdminModel> temporadaModel = new List<TemporadaAdminModel>();

            temporadaModel = temporadaBusiness.mostrarTemporada();

            ViewBag.listarTemporadas = temporadaModel;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("/Views/Administrador/VistaTemporadas/ModificarEliminarTemporadaView.cshtml");

        }


        public IActionResult ModificarTemporada(TemporadaAdminModel tempModel)
        {

            //Se crea un objeto temporada y se le asigna un valor desde la base de datos
            int valido = 0;

            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(Configuration);
            valido = temporadaBusiness.ModificarTemporada(tempModel);

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return new JsonResult(valido);

        }


        public IActionResult EliminarTemporada(string TN_Id_Temporada)
        {

            int valido = 0;

            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(Configuration);
            valido = temporadaBusiness.EliminarTemporada(TN_Id_Temporada);

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return new JsonResult(valido);

        }



    }
}
