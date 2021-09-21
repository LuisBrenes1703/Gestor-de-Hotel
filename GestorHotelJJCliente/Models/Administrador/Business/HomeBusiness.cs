using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class HomeBusiness
    {
        public IConfiguration Configuration { get; }

        public HomeBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public int modificarPaginaHome(HotelAdminModel hotelAdminModel)
        {
            HomeData homeData = new HomeData(Configuration);
            return homeData.modificarPaginaHome(hotelAdminModel);

        }
    }
}
