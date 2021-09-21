using GestorHotelJJCliente.Models;
using GestorHotelJJCliente.Models.Administrador.Business;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GestorHotelJJCliente.Controllers
{
    public class ComoLlegarAdminController : Controller
    {
        public IConfiguration Configuration { get; }

        public ComoLlegarAdminController(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public IActionResult VerModificarTextoComoLlegar()
        {

            ComoLlegarAdminBusiness hotelAdministradorBusiness = new ComoLlegarAdminBusiness(Configuration);
            List<ComoLlegarAdminModel> comoLlegarModel = new List<ComoLlegarAdminModel>();
            comoLlegarModel = hotelAdministradorBusiness.cargarInfoComoLlegar();
            ViewBag.DireccionHotel = comoLlegarModel;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaComoLlegar/ModificarComoLlegarView.cshtml");
        }


        public IActionResult ModificarTextoComoLlegar(ComoLlegarAdminModel ComoLlegarAdminModel)
        {
            //return new JsonResult(ComoLlegarAdminModel.TC_Descripcion + " id "+ComoLlegarAdminModel.TN_Id_Direccion);

            ComoLlegarAdminBusiness hotelAdministradorBusiness = new ComoLlegarAdminBusiness(Configuration);
            int valido = hotelAdministradorBusiness.modificarPaginaComoLlegar(ComoLlegarAdminModel);

            //ComoLlegarAdminBusiness hotelAdministradorBusiness = new ComoLlegarAdminBusiness(Configuration);
            List<ComoLlegarAdminModel> comoLlegarModel = new List<ComoLlegarAdminModel>();
            comoLlegarModel = hotelAdministradorBusiness.cargarInfoComoLlegar();
            ViewBag.DireccionHotel = comoLlegarModel;


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            if (valido == 1)
            {                
                ViewBag.Valido = "Se realizo la modificacion de manera correcta";
                return View("/Views/Administrador/VistaComoLlegar/ModificarComoLlegarView.cshtml");
            }
            else
            {
                ViewBag.Valido = "Ocurrio un error al realizar la modificación porfavor intentelo de nuevo";
                return View("/Views/Administrador/VistaComoLlegar/ModificarComoLlegarView.cshtml");
            }


        }

    }
}
