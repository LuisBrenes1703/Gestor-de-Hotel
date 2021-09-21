using GestorHotelJJCliente.Models;
using GestorHotelJJCliente.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Business
{
    public class BusinessFacilidades
    {
        public IConfiguration Configuration { get; }

        public BusinessFacilidades(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public List<FacilidadModel> getListarFacilidad()
        {
            DataFacilidades dataFacilidad = new DataFacilidades(Configuration);
            return dataFacilidad.getListarFacilidad();
        }




    }
}
