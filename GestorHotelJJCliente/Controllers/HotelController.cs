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
    public class HotelController : Controller
    {
        public IConfiguration Configuration { get; }

        public HotelController(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public IActionResult VerSobreNosotrosClientesView()
        {
            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;

            HotelBusiness hotelBusiness = new HotelBusiness(this.Configuration);
            HotelModel hotelModel = new HotelModel();

            hotelModel = hotelBusiness.VerSobreNosotrosClientesView();

            return View("/Views/VistaSobreNosotros/SobreNosotrosClienteView.cshtml", hotelModel);
        }

        public IActionResult VerContactenosClientesView()
        {
            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;

            HotelBusiness hotelBusiness = new HotelBusiness(this.Configuration);
            HotelModel hotelModel = new HotelModel();

            hotelModel = hotelBusiness.VerContactenosClientesView();

            return View("/Views/VistaContactenos/ContactenosClienteView.cshtml", hotelModel);
        }


        [HttpPost]
        public IActionResult CargarInicio()
        {
            HotelBusiness businessHotel = new HotelBusiness(Configuration);
            List<HotelModel> hotelModel = new List<HotelModel>();
            hotelModel = businessHotel.cargarInicio();
            ViewBag.InicioHotel = hotelModel;
            return View("/Views/Home/Index.cshtml");
        }







        public IActionResult VerComoLlegarClientesView()
        {
            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;

            HotelBusiness hotelBusiness = new HotelBusiness(this.Configuration);

            DireccionModel direccionModel = new DireccionModel();

            direccionModel = hotelBusiness.VerComoLlegarClientesView();

            return View("/Views/VistaUbicacion/ComoLlegarClienteView.cshtml", direccionModel);
        }




    }
}
