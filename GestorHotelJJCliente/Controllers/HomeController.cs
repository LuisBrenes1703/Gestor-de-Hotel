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

namespace GestorHotelJJCliente.Controllers
{
    public class HomeController : Controller
    {

        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public IActionResult Index()
        {
            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;

            HotelBusiness businessHotel = new HotelBusiness(Configuration);
            List<HotelModel> hotelModel = new List<HotelModel>();
            hotelModel = businessHotel.cargarInicio();
            ViewBag.InicioHotel = hotelModel;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
