using GestorHotelJJCliente.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Business
{
    public class HotelBusiness
    {

        public IConfiguration Configuration { get; }

        public HotelBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public HotelModel VerSobreNosotrosClientesView()
        {
            HotelData hotelData = new HotelData(this.Configuration);
            HotelModel hotelModel= new HotelModel();
            hotelModel = hotelData.VerSobreNosotrosClientesView();
            return hotelModel;
        }
        public List<HotelModel> cargarInicio()
        {
            HotelData hotelData = new HotelData(Configuration);
            return hotelData.cargarInicio();
        }


        public HotelModel VerContactenosClientesView()
        {
            HotelData hotelData = new HotelData(this.Configuration);
            HotelModel hotelModel = new HotelModel();
            hotelModel = hotelData.VerContactenosClientesView();
            return hotelModel;
        }



        public DireccionModel VerComoLlegarClientesView()
        {
            HotelData hotelData = new HotelData(this.Configuration);
            DireccionModel direccionModel = new DireccionModel();
            direccionModel = hotelData.VerComoLlegarClientesView();
            return direccionModel;
        }

       

    }
}
