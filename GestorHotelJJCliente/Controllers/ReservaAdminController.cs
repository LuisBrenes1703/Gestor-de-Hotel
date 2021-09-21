using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorHotelJJCliente.Models;
using GestorHotelJJCliente.Models.Administrador;
using GestorHotelJJCliente.Models.Administrador.Business;
using GestorHotelJJCliente.Models.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rotativa.AspNetCore;

namespace GestorHotelJJCliente.Controllers
{
    public class ReservaAdminController : Controller
    {
        public IConfiguration Configuration { get; }

        public ReservaAdminController(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public IActionResult ListaReservasView()
        {

           

            List<ReservasAdminModel> listaReservasHabitaciones = new List<ReservasAdminModel>();
            ReservaAdminBusiness ReservasBusiness = new ReservaAdminBusiness(Configuration);
            listaReservasHabitaciones = ReservasBusiness.getListaReservas();


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            ViewBag.ListaReservaciones = listaReservasHabitaciones;

            return View("/Views/Administrador/ReservasAdminViews/ListaReservasView.cshtml");
        }



        public IActionResult getReservaView(ReservasAdminModel reservaModel)
        {

            ReservasAdminModel listaReservasHabitaciones = new ReservasAdminModel();
            ReservaAdminBusiness ReservasBusiness = new ReservaAdminBusiness(Configuration);
            listaReservasHabitaciones = ReservasBusiness.getReservas(reservaModel.TN_Id_Reserva);


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            ViewBag.ListaReservaciones = listaReservasHabitaciones;

            //return new JsonResult(reservaModel.TN_Id_Reserva);
            return View("/Views/Administrador/ReservasAdminViews/DetallesReserva.cshtml");
        }


        public IActionResult eliminarReservaView(ReservasAdminModel reservaModel)
        {

            List<ReservasAdminModel> listaReservasHabitaciones = new List<ReservasAdminModel>();
            ReservaAdminBusiness ReservasBusiness = new ReservaAdminBusiness(Configuration);
            ReservasBusiness.EliminarReserva(reservaModel.TN_Id_Reserva);
            listaReservasHabitaciones = ReservasBusiness.getListaReservas();


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            ViewBag.ListaReservaciones = listaReservasHabitaciones;

            //return new JsonResult(reservaModel.TN_Id_Reserva);
            return View("/Views/Administrador/ReservasAdminViews/ListaReservasView.cshtml");
        }


        public IActionResult ReporteReservaView(ReservasAdminModel reservaModel)
        {

            //return new JsonResult(reservaModel.TN_Id_Reserva);



            ReservasAdminModel listaReservasHabitaciones = new ReservasAdminModel();
            ReservaAdminBusiness ReservasBusiness = new ReservaAdminBusiness(Configuration);
            listaReservasHabitaciones = ReservasBusiness.getReservas(reservaModel.TN_Id_Reserva);


           // ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            //ViewBag.ListaReservaciones = listaReservasHabitaciones;


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

           // ViewBag.ListaEstadoHabitaciones = listaEstadoHabitaciones;

            return new ViewAsPdf("/Views/Administrador/ReservasAdminViews/ReporteReservación.cshtml", listaReservasHabitaciones)
            {
            };

        }






















        public IActionResult VerEstadoHotelHoyView()
        {

            List<EstadoHotelModel> listaEstadoHabitaciones = new List<EstadoHotelModel>();
            HotelAdministradorBusiness hotelAdministradorBusiness = new HotelAdministradorBusiness(Configuration);
            listaEstadoHabitaciones = hotelAdministradorBusiness.getEstadosHabitaciones();


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            ViewBag.ListaEstadoHabitaciones = listaEstadoHabitaciones;

            return View("/Views/Administrador/VistaEstadoHotelHoy/VerEstadoHotelHoyView.cshtml");
        }


        public IActionResult VerDisponibilidadHotelHoyView()
        {

            List<EstadoHotelModel> listaEstadoHabitaciones = new List<EstadoHotelModel>();
            HotelAdministradorBusiness hotelAdministradorBusiness = new HotelAdministradorBusiness(Configuration);
            listaEstadoHabitaciones = hotelAdministradorBusiness.getEstadosHabitaciones();


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            ViewBag.ListaEstadoHabitaciones = listaEstadoHabitaciones;

            //return new JsonResult(estadoHotelModel.TN_TipoOperacion);
            return View("/Views/Administrador/VistaEstadoHotelHoy/DisponibilidadHabitaciones.cshtml");
        }


        public IActionResult ConsultarDisponibilidadHabitaciones()
        {
            //return new JsonResult("llegue consultar");
            TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
            listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaHabitacion;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            ViewBag.ListaHabitacionesDisponibles = null;

            return View("/Views/Administrador/ConsultarDisponibilidadHabitaciones/ConsultarDisponibilidadHabitaciones.cshtml");
        }


        public IActionResult ConsultarDisponbilidadHabitaciones(EstadoHotelModel estadoHotelModel)
        {

            //return new JsonResult(estadoHotelModel.TN_TipoOperacion);

            TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
            listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaHabitacion;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            ViewBag.fechas = null;

            //Fecha
            var Date = DateTime.Now.ToString("dd-MM-yyyy");
            DateTime hoy = DateTime.Today;

            //return new JsonResult(fInicio.Year + " - " + reservaModel.TC_FechaInicio.Year);
            if (hoy > estadoHotelModel.TC_FechaInicio || estadoHotelModel.TC_FechaInicio >= estadoHotelModel.TC_FechaFin)
            {
                ViewBag.fechas = "Error con el rango de fechas";
                return View("/Views/Administrador/ConsultarDisponibilidadHabitaciones/ConsultarDisponibilidadHabitaciones.cshtml");

            }


            List<EstadoHotelModel> listaHabitacionesDisponibles = new List<EstadoHotelModel>();
            HotelAdministradorBusiness hotelAdministradorBusiness = new HotelAdministradorBusiness(Configuration);
            listaHabitacionesDisponibles = hotelAdministradorBusiness.getDisponibilidadHabitaciones(estadoHotelModel);

            if (estadoHotelModel.TN_TipoOperacion == 1)
            {

                return new ViewAsPdf("/Views/Administrador/VistaEstadoHotelHoy/ReporteHabitacionesGeneral.cshtml", listaHabitacionesDisponibles)
                {
                };
            }
            else
            {

                ViewBag.ListaHabitacionesDisponibles = listaHabitacionesDisponibles;
                return View("/Views/Administrador/ConsultarDisponibilidadHabitaciones/ConsultarDisponibilidadHabitaciones.cshtml");

            }


        }



        public IActionResult VerCrearOferta()
        {

            TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
            listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaHabitacion;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("/Views/Administrador/VistaOfertas/CrearOfertaView.cshtml");

        }

        public IActionResult VerModificarEliminarOferta()
        {

            TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
            listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaHabitacion;


            OfertaAdminBusiness ofertaAdminBusiness = new OfertaAdminBusiness(Configuration);
            List <OfertaAdminModel> listaOfertas = new List<OfertaAdminModel>();
            listaOfertas = ofertaAdminBusiness.cargarIdNombresOfertas();          

            ViewBag.listaOfertas = listaOfertas;


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
            return View("/Views/Administrador/VistaOfertas/ModificarEliminarOfertaView.cshtml");

        }
        public IActionResult VerModificarSobreNosotros()
        {
            SobreNosotrosAdminBusiness sobreNosotrosBusiness = new SobreNosotrosAdminBusiness(this.Configuration);
            SobreNosotrosAdminModel sobreNosotrosModel = new SobreNosotrosAdminModel();
            sobreNosotrosModel = sobreNosotrosBusiness.VerSobreNosotrosClientesView();
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");
       
            return View("/Views/Administrador/VistaSobreNosotros/ModificarSobreNosotros.cshtml", sobreNosotrosModel);

        }

        [HttpPost]
        public IActionResult ReporteEstadoHotelHoyView()
        {

            List<EstadoHotelModel> listaEstadoHabitaciones = new List<EstadoHotelModel>();
            HotelAdministradorBusiness hotelAdministradorBusiness = new HotelAdministradorBusiness(Configuration);
            listaEstadoHabitaciones = hotelAdministradorBusiness.getEstadosHabitaciones();


            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            ViewBag.ListaEstadoHabitaciones = listaEstadoHabitaciones;

            return new ViewAsPdf("/Views/Administrador/VistaEstadoHotelHoy/ReporteHabitacionesGeneral.cshtml", listaEstadoHabitaciones)
            {
            };

        }


        public IActionResult VerModificarFacilidades()
        {
            List<FacilidadesAdminModel> listaFacilidades = new List<FacilidadesAdminModel>();
            FacilidadesAdminBusiness businessFacilidades = new FacilidadesAdminBusiness(Configuration);
            listaFacilidades = businessFacilidades.getListarFacilidad();

            ViewBag.listarFacilidades = listaFacilidades;
            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/VistaFacilidades/ModificaFacilidadesView.cshtml");

        }


        public IActionResult VerModificarTextoHome()
        {

            HotelAdministradorBusiness hotelAdministradorBusiness = new HotelAdministradorBusiness(Configuration);
            List<HotelAdminModel> hotelModel = new List<HotelAdminModel>();
            hotelModel = hotelAdministradorBusiness.cargarInfoHome();
            ViewBag.InicioHotel = hotelModel;

            ViewBag.PermisoUsuario = HttpContext.Session.GetString("UsuarioPermiso");

            return View("/Views/Administrador/Home/ModificarHomeView.cshtml");
        }


    }
}
