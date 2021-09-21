using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class TipoHabitacionAdminBusiness
    {

        public IConfiguration Configuration { get; }

        public TipoHabitacionAdminBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public List<TipoHabitacionAdminModel> VerTipoHabitacion()
        {

            TipoHabitacionAdminData tipoHabitacionData = new TipoHabitacionAdminData(Configuration);

            return tipoHabitacionData.VerTipoHabitacion();

        }

        public bool CrearTipoHabitacion(TipoHabitacionAdminModel tipoHabitacionAdminModel)
        {

            TipoHabitacionAdminData tipoHabitacionData = new TipoHabitacionAdminData(Configuration);

            return tipoHabitacionData.CrearTipoHabitacion(tipoHabitacionAdminModel);

        }

        public bool ModificarTipoHabitacion(TipoHabitacionAdminModel tipoHabitacionAdminModel)
        {

            TipoHabitacionAdminData tipoHabitacionData = new TipoHabitacionAdminData(Configuration);

            return tipoHabitacionData.ModificarTipoHabitacion(tipoHabitacionAdminModel);

        }

    }
}
