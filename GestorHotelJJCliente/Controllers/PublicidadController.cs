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
    public class PublicidadController : Controller
    {
        public IConfiguration Configuration { get; }

        public PublicidadController(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        [HttpPost]
        public IActionResult CargarPublicidad()
        {
            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;
            return View("/Views/Home/Index.cshtml");
        }

    }
}