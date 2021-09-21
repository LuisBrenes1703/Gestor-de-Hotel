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
    public class OfertaController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public IConfiguration Configuration { get; }

        public OfertaController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        } // constructor


        [HttpPost]
        public IActionResult CargarOferta()
        {
            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;
            return View("/Views/Home/Index.cshtml");

        }

        [HttpPost]
        public IActionResult AgregarOferta(OfertaAdminModel ofertaAdminModel)
        {
           // return new JsonResult("hola" + ofertaAdminModel.imagenOferta);
            //return new JsonResult("inicio: "+ofertaAdminModel.TC_FechaInicio +" fin: " + ofertaAdminModel.TC_FechaFin +" porcentaje: " + ofertaAdminModel.TC_PorcentajeOferta +" id: " + ofertaAdminModel.TN_Id_TipoHabitacion + " nombre:"  + ofertaAdminModel.TC_Nombre_Oferta + " ofertaAdminModel.imagenOferta"+ ofertaAdminModel.imagenOferta);


            if (ofertaAdminModel.TN_Id_TipoHabitacion != 0)
            {


                var Date = DateTime.Now.ToString("dd-MM-yyyy");
                DateTime hoy = DateTime.Today;

                if (hoy >= ofertaAdminModel.TC_Fecha_Inicio || ofertaAdminModel.TC_Fecha_Inicio >= ofertaAdminModel.TC_Fecha_Fin)
                {
                    TipoHabitacionBusiness businessHabitacion1 = new TipoHabitacionBusiness(Configuration);
                    List<TipoHabitacionModel> listaHabitacion1 = new List<TipoHabitacionModel>();
                    listaHabitacion1 = businessHabitacion1.ObtenerTipoHabitacion();
                    ViewBag.ListaTipoHabitacion = listaHabitacion1;


                    ViewBag.fechas = "Error con el rango de fechas";
                    ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                    return View("/Views/Administrador/VistaOfertas/CrearOfertaView.cshtml");

                }
                             
             
                OfertaAdminBusiness ofertaAdminBusiness = new OfertaAdminBusiness(Configuration);
                int valido = ofertaAdminBusiness.agregarOferta(ofertaAdminModel);

                if (valido == 0)
                {
                    ViewBag.validacion = "Se a producido un error al insertar la oferta porfavor intentelo de nuevo";
                }

                string imagen = ofertaAdminModel.TC_Nombre_Oferta;
                imagen += ".jpg";

                if (ofertaAdminModel.imagenOferta != null)
                {
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/oferta");
                    var filePath = Path.Combine(uploads, imagen);
                    FileStream f = new FileStream(filePath, FileMode.Create);
                    ofertaAdminModel.imagenOferta.CopyTo(f);
                    f.Close();
                };



                TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
                List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
                listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
                ViewBag.ListaTipoHabitacion = listaHabitacion;

                ViewBag.validacion = "Se guardo la oferta de manera exitosa";
                ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                return View("/Views/Administrador/VistaOfertas/CrearOfertaView.cshtml");


            }
            else {

                TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
                List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
                listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
                ViewBag.ListaTipoHabitacion = listaHabitacion;


                ViewBag.validacion = "No selecciono el tipo de habitacion";
                ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                return View("/Views/Administrador/VistaOfertas/CrearOfertaView.cshtml");
            }

        }


        [HttpPost]
        public IActionResult IrModificarOferta(OfertaAdminModel ofertaAdminModel)
        {

            OfertaAdminBusiness ofertaAdminBusiness = new OfertaAdminBusiness(Configuration);
            OfertaAdminModel oferta1 = new OfertaAdminModel();
            oferta1 = ofertaAdminBusiness.cargarOferta(ofertaAdminModel);            
           // return new JsonResult(oferta1.TC_Nombre_Oferta);

            TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
            listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaHabitacion;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("/Views/Administrador/VistaOfertas/ModificarOferta.cshtml", oferta1);
        }




        [HttpPost]
        public IActionResult ModificarOferta(OfertaAdminModel ofertaAdminModel)
        {
            //return new JsonResult(ofertaAdminModel.TN_Id_Oferta + " inicio: " + ofertaAdminModel.TC_Fecha_Inicio + " fin: " + ofertaAdminModel.TC_Fecha_Fin + " porcentaje: " + ofertaAdminModel.TC_PorcentajeOferta + " id: " + ofertaAdminModel.TN_Id_TipoHabitacion + " nombre:" + ofertaAdminModel.TC_Nombre_Oferta + " ofertaAdminModel.imagenOferta" + ofertaAdminModel.imagenOferta);
            //  return new JsonResult(ofertaAdminModel.TN_Id_Oferta);
            if (ofertaAdminModel.TN_Id_TipoHabitacion != 0)
            {

                var Date = DateTime.Now.ToString("dd-MM-yyyy");
                DateTime hoy = DateTime.Today;

                if (hoy >= ofertaAdminModel.TC_Fecha_Inicio || ofertaAdminModel.TC_Fecha_Inicio >= ofertaAdminModel.TC_Fecha_Fin)
                {

                    OfertaAdminBusiness ofertaAdminBusiness3 = new OfertaAdminBusiness(Configuration);
                    OfertaAdminModel oferta3 = new OfertaAdminModel();
                    oferta3 = ofertaAdminBusiness3.cargarOferta(ofertaAdminModel);

                    TipoHabitacionBusiness businessHabitacion1 = new TipoHabitacionBusiness(Configuration);
                    List<TipoHabitacionModel> listaHabitacion1 = new List<TipoHabitacionModel>();
                    listaHabitacion1 = businessHabitacion1.ObtenerTipoHabitacion();
                    ViewBag.ListaTipoHabitacion = listaHabitacion1;

                    ViewBag.fechas = "Error con el rango de fechas";
                    ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                    return View("/Views/Administrador/VistaOfertas/ModificarOferta.cshtml", oferta3);

                }


                OfertaAdminBusiness ofertaAdminBusiness = new OfertaAdminBusiness(Configuration);
                OfertaAdminModel ofertaAdminModelSalida = new OfertaAdminModel();
                ofertaAdminModelSalida = ofertaAdminBusiness.modificarOferta(ofertaAdminModel);

                if (ofertaAdminModelSalida.valido == 0)
                {
                    OfertaAdminBusiness ofertaAdminBusiness2 = new OfertaAdminBusiness(Configuration);
                    OfertaAdminModel oferta2 = new OfertaAdminModel();
                    oferta2 = ofertaAdminBusiness2.cargarOferta(ofertaAdminModel);

                    TipoHabitacionBusiness businessHabitacion1 = new TipoHabitacionBusiness(Configuration);
                    List<TipoHabitacionModel> listaHabitacion1 = new List<TipoHabitacionModel>();
                    listaHabitacion1 = businessHabitacion1.ObtenerTipoHabitacion();
                    ViewBag.ListaTipoHabitacion = listaHabitacion1;
                    
                    ViewBag.validacion = "Se a producido un error al modificar la oferta porfavor intentelo de nuevo";
                    ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                    return View("/Views/Administrador/VistaOfertas/ModificarOferta.cshtml", oferta2);
                }

                string imagen = ofertaAdminModel.TC_Nombre_Oferta;
                imagen += ".jpg";

                if (ofertaAdminModel.imagenOferta != null)
                {
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/oferta");
                    var filePath = Path.Combine(uploads, imagen);
                    FileStream f = new FileStream(filePath, FileMode.Create);
                    ofertaAdminModel.imagenOferta.CopyTo(f);
                    f.Close();
                };

                OfertaAdminBusiness ofertaAdminBusiness1 = new OfertaAdminBusiness(Configuration);
                OfertaAdminModel oferta1 = new OfertaAdminModel();
                oferta1 = ofertaAdminBusiness1.cargarOferta(ofertaAdminModel);

                TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
                List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
                listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
                ViewBag.ListaTipoHabitacion = listaHabitacion;

                ViewBag.validacion = "Se modifico la oferta de manera exitosa";
                ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                return View("/Views/Administrador/VistaOfertas/ModificarOferta.cshtml", oferta1);

            }
            else
            {
                OfertaAdminBusiness ofertaAdminBusiness1 = new OfertaAdminBusiness(Configuration);
                OfertaAdminModel oferta1 = new OfertaAdminModel();
                oferta1 = ofertaAdminBusiness1.cargarOferta(ofertaAdminModel);

                TipoHabitacionBusiness businessHabitacion1 = new TipoHabitacionBusiness(Configuration);
                List<TipoHabitacionModel> listaHabitacion1 = new List<TipoHabitacionModel>();
                listaHabitacion1 = businessHabitacion1.ObtenerTipoHabitacion();
                ViewBag.ListaTipoHabitacion = listaHabitacion1;

                ViewBag.validacion = "No selecciono el tipo de habitacion";
                ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
                return View("/Views/Administrador/VistaOfertas/ModificarOferta.cshtml", oferta1);
            }

        }


        [HttpPost]
        public IActionResult EliminarOferta(OfertaAdminModel ofertaAdminModel)
        {

          //  return new JsonResult(ofertaAdminModel.TN_Id_Oferta);
            OfertaAdminBusiness ofertaAdminBusiness = new OfertaAdminBusiness(Configuration);
            int valido = ofertaAdminBusiness.EliminarOferta(ofertaAdminModel);

            TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
            listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaHabitacion;

            //OfertaAdminBusiness ofertaAdminBusiness = new OfertaAdminBusiness(Configuration);
            List<OfertaAdminModel> listaOfertas = new List<OfertaAdminModel>();
            listaOfertas = ofertaAdminBusiness.cargarIdNombresOfertas();

            ViewBag.listaOfertas = listaOfertas;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("/Views/Administrador/VistaOfertas/ModificarEliminarOfertaView.cshtml");




        }


    }
}
