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
    public class SobreNosotrosAdminController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public IConfiguration Configuration { get; }

        public SobreNosotrosAdminController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        } // constructor


        public IActionResult ModificarTexto(SobreNosotrosAdminModel SobreNosotrosModel)
        {
            int valido = 0;
            SobreNosotrosAdminBusiness sobreNosotrosBusiness = new SobreNosotrosAdminBusiness(Configuration);
            valido = sobreNosotrosBusiness.ModificarTexto(SobreNosotrosModel.TN_Id_Hotel, SobreNosotrosModel.TC_SobreNosotros);
            SobreNosotrosAdminModel sobreNosotrosModel = new SobreNosotrosAdminModel();
            sobreNosotrosModel = sobreNosotrosBusiness.VerSobreNosotrosClientesView();
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaSobreNosotros/ModificarSobreNosotros.cshtml", sobreNosotrosModel);
        }

        public IActionResult AgregarFoto(IFormFile TC_URL_IMG)
        {
            FotoModel fotoModel = new FotoModel();

            int valido = 0;
            string msjValido;

            string ruta = "assets/img/gallery";

            if (TC_URL_IMG != null)
            {
                fotoModel.TC_URL_IMG = "\\assets\\img\\gallery\\" + TC_URL_IMG.FileName;

            }

            SobreNosotrosAdminBusiness sobreNosotrosAdminBusiness = new SobreNosotrosAdminBusiness(Configuration);

            valido = sobreNosotrosAdminBusiness.AgregarFoto(fotoModel);


            if (valido == 1)
            {
                if (TC_URL_IMG != null)
                {
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, ruta);
                    var filePath = Path.Combine(uploads, TC_URL_IMG.FileName);

                    if (!Directory.Exists(filePath))
                    {

                        FileStream f = new FileStream(filePath, FileMode.Create);
                        TC_URL_IMG.CopyTo(f);
                        f.Close();

                    }
                }

                msjValido = "Exito al guardar la foto";
            }
            else
            {
                msjValido = "No se pudo guardar la foto";
            }

            ViewBag.Valido = msjValido;

            SobreNosotrosAdminBusiness sobreNosotrosBusiness = new SobreNosotrosAdminBusiness(this.Configuration);
            SobreNosotrosAdminModel sobreNosotrosModel = new SobreNosotrosAdminModel();
            sobreNosotrosModel = sobreNosotrosBusiness.VerSobreNosotrosClientesView();
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaSobreNosotros/ModificarSobreNosotros.cshtml", sobreNosotrosModel);


        }

        public IActionResult EliminarFoto(FotoModel fotoModel)
        {

            //return new JsonResult("ola" +fotoModel.TN_Id_Galeria);
            int valido = 0;
            SobreNosotrosAdminBusiness sobreNosotrosBusiness = new SobreNosotrosAdminBusiness(Configuration);
            valido = sobreNosotrosBusiness.EliminarFotoGaleria(fotoModel);

            
            SobreNosotrosAdminModel sobreNosotrosModel = new SobreNosotrosAdminModel();
            sobreNosotrosModel = sobreNosotrosBusiness.VerSobreNosotrosClientesView();
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaSobreNosotros/ModificarSobreNosotros.cshtml", sobreNosotrosModel);


            
        }


        


    }
}
