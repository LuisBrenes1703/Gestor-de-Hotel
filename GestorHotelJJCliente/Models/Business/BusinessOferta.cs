using GestorHotelJJCliente.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Business
{
    public class BusinessOferta
    {
        public IConfiguration Configuration { get; }
        public BusinessOferta(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor
        public List<OfertaModel> cargarOferta( )
        {
            DataOferta dataPublicidad = new DataOferta(Configuration);
            return dataPublicidad.cargarOferta();
        }
    }
}
