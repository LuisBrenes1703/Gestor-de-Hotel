using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class ComoLlegarAdminBusiness
    {
        public IConfiguration Configuration { get; }

        public ComoLlegarAdminBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public List<ComoLlegarAdminModel> cargarInfoComoLlegar()
        {
            ComoLlegarAdminData hotelData = new ComoLlegarAdminData(Configuration);
            return hotelData.cargarInfoComoLlegar();
        }

        public int modificarPaginaComoLlegar(ComoLlegarAdminModel comoLlegarAdminModel)
        {
            ComoLlegarAdminData homeData = new ComoLlegarAdminData(Configuration);
            return homeData.modificarPaginaComoLlegar(comoLlegarAdminModel);

        }

    }
}
