using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestorHotelJJCliente.Models;
using GestorHotelJJCliente.Models.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using GestorHotelJJCliente.Models.Administrador.Business;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace GestorHotelJJCliente.Controllers
{
    public class HomeAdminController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public IConfiguration Configuration { get; }

        public HomeAdminController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        } // constructor

        [HttpPost]
        public IActionResult ModificarTextoHome(HotelAdminModel hotelAdminModel)
        {
            //return new JsonResult( hotelAdminModel.TC_Inicio);
          
            HomeBusiness homeBusiness = new HomeBusiness(Configuration);
            int valido = homeBusiness.modificarPaginaHome(hotelAdminModel);

            HotelAdministradorBusiness hotelAdministradorBusiness = new HotelAdministradorBusiness(Configuration);
            List<HotelAdminModel> hotelModel = new List<HotelAdminModel>();
            hotelModel = hotelAdministradorBusiness.cargarInfoHome();
            ViewBag.InicioHotel = hotelModel;


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            if (valido == 1)
            {

                string imagen = "Legendary";
                imagen += ".jpg";

                if (hotelAdminModel.imagenHome != null)
                {
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/hotel");
                    var filePath = Path.Combine(uploads, imagen);
                    FileStream f = new FileStream(filePath, FileMode.Create);
                    hotelAdminModel.imagenHome.CopyTo(f);
                    f.Close();
                };


                ViewBag.Valido = "Se realizo la modificacion de manera correcta";
                return View("/Views/Administrador/Home/ModificarHomeView.cshtml");
            }
            else {
              
                ViewBag.Valido = "Ocurrio un error al realizar la modificación porfavor intentelo de nuevo";
                return View("/Views/Administrador/Home/ModificarHomeView.cshtml");
            }

           
        }


    }
}
