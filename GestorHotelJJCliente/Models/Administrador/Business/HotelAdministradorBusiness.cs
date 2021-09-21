using GestorHotelJJCliente.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class HotelAdministradorBusiness
    {
        public IConfiguration Configuration { get; }

        public HotelAdministradorBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public List<EstadoHotelModel> getEstadosHabitaciones()
        {
            HotelAdministradorData dataHotel = new HotelAdministradorData(Configuration);
            return dataHotel.getEstadosHabitaciones();
         
        }


        public List<EstadoHotelModel> getDisponibilidadHabitaciones(EstadoHotelModel estadoHotelModel)
        {
            HotelAdministradorData dataHotel = new HotelAdministradorData(Configuration);
            return dataHotel.getDisponibilidadHabitaciones(estadoHotelModel);

        }
        public List<HotelAdminModel> cargarInfoHome()
        {
            HotelAdministradorData hotelData = new HotelAdministradorData(Configuration);
            return hotelData.cargarInfoHome();
        }


        public int modificarDisponibilidad(EstadoHotelModel estadoModel)
        {
            HotelAdministradorData hotelData = new HotelAdministradorData(Configuration);
            return hotelData.modificarDisponibilidad(estadoModel);
        }

        public HotelAdminModel obtieneContactos()
        {
            HotelAdministradorData hotelData = new HotelAdministradorData(Configuration);
            return hotelData.obtieneContactos();
        }

        public bool ModificarContactos(HotelAdminModel hotelModel)
        {
            HotelAdministradorData hotelData = new HotelAdministradorData(Configuration);
            return hotelData.ModificarContactos(hotelModel);
        }

    }
}
