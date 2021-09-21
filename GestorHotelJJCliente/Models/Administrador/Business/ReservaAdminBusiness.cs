using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class ReservaAdminBusiness
    {
        public IConfiguration Configuration { get; }
        public ReservaAdminBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public List<ReservasAdminModel> getListaReservas()
        {
            ReservasAdminData reservaAdminData = new ReservasAdminData(Configuration);
            return reservaAdminData.getListaReservas();
        }

        public ReservasAdminModel getReservas(int TN_Id_Reserva)
        {
            ReservasAdminData reservaAdminData = new ReservasAdminData(Configuration);
            return reservaAdminData.getReservas(TN_Id_Reserva);

        }

        public int EliminarReserva(int TN_Id_Reserva)
        {
            ReservasAdminData reservaAdminData = new ReservasAdminData(Configuration);
            return reservaAdminData.EliminarReserva(TN_Id_Reserva);

        }
        




    }
}
