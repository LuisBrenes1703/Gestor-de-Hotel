using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestorHotelJJCliente.Models;
using Microsoft.Extensions.Configuration;
using GestorHotelJJCliente.Models.Business;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using GestorHotelJJCliente.Models.Administrador.Business;
using System.IO;

namespace GestorHotelJJCliente.Controllers
{
    public class FacilidadController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public IConfiguration Configuration { get; }

        public FacilidadController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        } // constructoronfiguration;


        public IActionResult VerFacilidadClienteView()
        {
            List<FacilidadModel> listaFacilidades = new List<FacilidadModel>();
            BusinessFacilidades businessCatalogo = new BusinessFacilidades(Configuration);
            listaFacilidades = businessCatalogo.getListarFacilidad();

            ViewBag.ListaFacilidad = listaFacilidades;

            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;

            return View("/Views/VistaFacilidad/FacilidadClienteView.cshtml");
        }

        public IActionResult ModificarFacilidades(int TN_Id_Facilidad, string TC_Descripcion_Facilidad, IFormFile TC_URL_IMG, string TC_URL_IMG_N)
        {

            FacilidadesAdminModel facilidadesAdminModel = new FacilidadesAdminModel();

            bool valido = false;
            string msjValido;

            string ruta = "assets/img/Facilidad";



            facilidadesAdminModel.TN_Id_Facilidad = TN_Id_Facilidad;
            facilidadesAdminModel.TC_Descripcion_Facilidad = TC_Descripcion_Facilidad;

            if (TC_URL_IMG != null)
            {
                facilidadesAdminModel.TC_URL_IMG = "\\assets\\img\\Facilidad\\" + TC_URL_IMG.FileName;

            }
            else
            {
                facilidadesAdminModel.TC_URL_IMG = TC_URL_IMG_N;
            }

            FacilidadesAdminBusiness facilidadesAdminBusiness = new FacilidadesAdminBusiness(Configuration);


            valido = facilidadesAdminBusiness.ModificarFacilidades(facilidadesAdminModel);


            if (valido == true)
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

                msjValido = "Exito al actualizar las Facilidades";
            }
            else
            {
                msjValido = "No se pudo actualizar las Facilidades";
            }

            ViewBag.Valida = msjValido;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            List<FacilidadesAdminModel> listaFacilidades = new List<FacilidadesAdminModel>();
            listaFacilidades = facilidadesAdminBusiness.getListarFacilidad();

            ViewBag.listarFacilidades = listaFacilidades;
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaFacilidades/ModificaFacilidadesView.cshtml");

        }

       

    }
}
