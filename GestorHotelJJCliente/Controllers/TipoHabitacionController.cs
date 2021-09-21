using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using GestorHotelJJCliente.Models;
using Microsoft.Extensions.Configuration;
using GestorHotelJJCliente.Models.Business;
using GestorHotelJJCliente.Models.Administrador;
using GestorHotelJJCliente.Models.Administrador.Business;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GestorHotelJJCliente.Controllers
{
    public class TipoHabitacionController : Controller
    {

        private readonly IHostingEnvironment hostingEnvironment;
        public IConfiguration Configuration { get; }

        public TipoHabitacionController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        } // constructor

        public IActionResult VerTarifasClienteView()
        {
            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;


            TipoHabitacionBusiness tipoHabitacionBusiness = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaTipoHabitacion = new List<TipoHabitacionModel>();
            listaTipoHabitacion = tipoHabitacionBusiness.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaTipoHabitacion;

            return View("/Views/VistaTarifas/TarifasClienteView.cshtml");
        }

        public IActionResult VerCRUDTipoHabitacion()
        {

            TipoHabitacionAdminBusiness tipoHabitacionAdminBusiness = new TipoHabitacionAdminBusiness(Configuration);
            List<TipoHabitacionAdminModel> tipoHabitacionAdminModel = new List<TipoHabitacionAdminModel>();

            tipoHabitacionAdminModel = tipoHabitacionAdminBusiness.VerTipoHabitacion();

            ViewBag.listarTipoHabitacion = tipoHabitacionAdminModel;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("/Views/Administrador/VistaTipoHabitacion/CRUDTipoHabitacionView.cshtml");

        }


        public IActionResult VerCrearTipoHabitacion(TipoHabitacionAdminModel tipoHabitacionAdminModel)
        {

            TipoHabitacionAdminBusiness tipoHabitacionAdminBusiness = new TipoHabitacionAdminBusiness(Configuration);
            
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("/Views/Administrador/VistaTipoHabitacion/CrearTipoHabitacionView.cshtml");

        }

        public IActionResult CrearTipoHabitacion(string TC_TipoHabitacion, string TC_Descripcion, float TC_Tarifa, int TN_Cantidad, IFormFile TC_URL_IMG)
        {

            TipoHabitacionAdminModel tipoHabitacionAdminModel = new TipoHabitacionAdminModel();
            TipoHabitacionAdminBusiness tipoHabitacionAdminBusiness = new TipoHabitacionAdminBusiness(Configuration);

            bool valido = false;
            string msjValido;

            string ruta = "assets/img/habitaciones";




            tipoHabitacionAdminModel.TC_TipoHabitacion = TC_TipoHabitacion;
            tipoHabitacionAdminModel.TC_Descripcion = TC_Descripcion;
            tipoHabitacionAdminModel.TC_Tarifa = TC_Tarifa;
            tipoHabitacionAdminModel.TN_Cantidad = TN_Cantidad;
            tipoHabitacionAdminModel.TC_URL_IMG = "\\assets\\img\\habitaciones\\" + TC_URL_IMG.FileName;


            valido = tipoHabitacionAdminBusiness.CrearTipoHabitacion(tipoHabitacionAdminModel);


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

                msjValido = "Exito al crear Tipo de Habitación";
            }
            else
            {
                msjValido = "No se pudo crear Tipo de Habitación";
            }

            ViewBag.validacion = msjValido;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");


            return View("/Views/Administrador/VistaTipoHabitacion/CrearTipoHabitacionView.cshtml");

        }


        public IActionResult ModificarTipoHabitacion(int TN_Id_TipoHabitacion, string TC_Descripcion, float TC_Tarifa, IFormFile TC_URL_IMG, string TC_URL_IMG_N)
        {
            
            TipoHabitacionAdminModel tipoHabitacionAdminModel = new TipoHabitacionAdminModel();

            bool valido = false;
            string msjValido ;

            string ruta = "assets/img/habitaciones";




            tipoHabitacionAdminModel.TN_Id_TipoHabitacion = TN_Id_TipoHabitacion;
            tipoHabitacionAdminModel.TC_Descripcion = TC_Descripcion;
            tipoHabitacionAdminModel.TC_Tarifa = TC_Tarifa;

            if (TC_URL_IMG != null)
            {
                tipoHabitacionAdminModel.TC_URL_IMG = "\\assets\\img\\habitaciones\\" + TC_URL_IMG.FileName;

            }
            else {
                tipoHabitacionAdminModel.TC_URL_IMG = TC_URL_IMG_N;
            }
            TipoHabitacionAdminBusiness tipoHabitacionAdminBusiness = new TipoHabitacionAdminBusiness(Configuration);
           

            valido = tipoHabitacionAdminBusiness.ModificarTipoHabitacion(tipoHabitacionAdminModel);


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

                msjValido = "Exito al actualizar Tipo de Habitación";
            }
            else
            {
                msjValido = "No se pudo actualizar Tipo de Habitación";
            }


            List<TipoHabitacionAdminModel> listatipoHabitacionAdminModel = new List<TipoHabitacionAdminModel>();

            listatipoHabitacionAdminModel = tipoHabitacionAdminBusiness.VerTipoHabitacion();

            ViewBag.listarTipoHabitacion = listatipoHabitacionAdminModel;

            ViewBag.Valida = msjValido;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaTipoHabitacion/CRUDTipoHabitacionView.cshtml");

        }


    }
}
