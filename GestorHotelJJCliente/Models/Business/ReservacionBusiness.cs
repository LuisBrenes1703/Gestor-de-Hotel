using GestorHotelJJCliente.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Business
{
    public class ReservacionBusiness
    {
        public IConfiguration Configuration { get; }

        public ReservacionBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public InformacionClienteModel BuscarDisponibilidadHabitacion(ReservaModel reservaModel)
        {
            ReservaciónData reservaciónData = new ReservaciónData(this.Configuration);
            return reservaciónData.BuscarDisponibilidadHabitacion(reservaModel);
        }

        public InformacionClienteModel BuscarDatos(ReservaModel reservaModel)
        {
            ReservaciónData reservaciónData = new ReservaciónData(this.Configuration);
            return reservaciónData.BuscarDatos(reservaModel);
        }

        public InformacionClienteModel RealizarReservacion(InformacionClienteModel informacionClienteModel)
        {
            ReservaciónData reservaciónData = new ReservaciónData(this.Configuration);
            return reservaciónData.RealizarReservacion(informacionClienteModel);
        }


    }
}
