using GestorHotelJJCliente.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Business
{
    public class BusinessPublicidad
    {
        public IConfiguration Configuration { get; }
        public BusinessPublicidad(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor
        public List<PublicidadModel> cargarPublicidad( )
        {
            DataPublicidad dataPublicidad = new DataPublicidad(Configuration);
            return dataPublicidad.cargarPublicidad();
        }
    }
}
