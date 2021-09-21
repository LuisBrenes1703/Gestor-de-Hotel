using GestorHotelJJCliente.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Business
{
    public class TipoHabitacionBusiness
    {

        public IConfiguration Configuration { get; }
        public TipoHabitacionBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public List<TipoHabitacionModel> ObtenerTipoHabitacion()
        {
            TipoHabitacionData dataTipoHabitacion = new TipoHabitacionData(Configuration);
            return dataTipoHabitacion.ObtenerTipoHabitacion();
        }

    }
}
