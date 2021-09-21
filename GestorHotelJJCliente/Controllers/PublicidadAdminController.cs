using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestorHotelJJCliente.Models;
using GestorHotelJJCliente.Models.Administrador.Business;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GestorHotelJJCliente.Controllers
{
    public class PublicidadAdminController : Controller
    {

        private readonly IHostingEnvironment hostingEnvironment;
        public IConfiguration Configuration { get; }

        public PublicidadAdminController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        } // constructoronfiguration;


        public IActionResult VerModificarPublicidadView()
        {
            PublicidadModel publicidadModel = new PublicidadModel();
            PublicidadAdminBusiness publicidadBusiness = new PublicidadAdminBusiness(Configuration);
            publicidadModel = publicidadBusiness.ObtenerPublicidad();

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaPublicidad/ModificarPublicidadView.cshtml", publicidadModel);

        }


        [HttpPost]
        public IActionResult ModificarPublicidad(PublicidadModel publicidadModel)
        {


           // return new JsonResult(publicidadModel.imagenPublicidad.FileName);

            int valido = 0;
            string msjValido;

            string ruta = "assets/img/public";

            if (publicidadModel.imagenPublicidad != null)
            {
                publicidadModel.TC_URL_IMG = "\\assets\\img\\public\\" + publicidadModel.imagenPublicidad.FileName;
            }
            else {
                publicidadModel.TC_URL_IMG = "null";
            }

            PublicidadAdminBusiness sobreNosotrosAdminBusiness = new PublicidadAdminBusiness(Configuration);

            valido = sobreNosotrosAdminBusiness.ModificarPublicidad(publicidadModel);


            if (valido == 1)
            {
                if (publicidadModel.imagenPublicidad != null)
                {
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, ruta);
                    var filePath = Path.Combine(uploads, publicidadModel.imagenPublicidad.FileName);

                    if (!Directory.Exists(filePath))
                    {

                        FileStream f = new FileStream(filePath, FileMode.Create);
                        publicidadModel.imagenPublicidad.CopyTo(f);
                        f.Close();

                    }
                }

                msjValido = "Exito al actualizar la información";
            }
            else
            {
                msjValido = "No se al actualizar la información";
            }


            ViewBag.Valido = msjValido;

            PublicidadModel publicidadModelSalida = new PublicidadModel();
            PublicidadAdminBusiness publicidadBusiness = new PublicidadAdminBusiness(Configuration);
            publicidadModelSalida = publicidadBusiness.ObtenerPublicidad();

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaPublicidad/ModificarPublicidadView.cshtml", publicidadModelSalida);

        }

    }
}
