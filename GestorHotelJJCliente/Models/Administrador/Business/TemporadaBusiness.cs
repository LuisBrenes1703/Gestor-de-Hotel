using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class TemporadaBusiness
    {
        public IConfiguration Configuration { get; }

        public TemporadaBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public int CrearTemporada(TemporadaAdminModel tempModel)
        {

            TemporadaData temporadaData = new TemporadaData(Configuration);

            return temporadaData.CrearTemporada(tempModel);

        }

        public List<TemporadaAdminModel> mostrarTemporada()
        {

            TemporadaData temporadaData = new TemporadaData(Configuration);

            return temporadaData.mostrarTemporada();

        }

        public int ModificarTemporada(TemporadaAdminModel tempModel)
        {

            TemporadaData temporadaData = new TemporadaData(Configuration);

            return temporadaData.ModificarTemporada(tempModel);

        }

        public int EliminarTemporada(string TN_Id_Temporada)
        {

            TemporadaData temporadaData = new TemporadaData(Configuration);

            return temporadaData.EliminarTemporada(TN_Id_Temporada);

        }

    }
}
