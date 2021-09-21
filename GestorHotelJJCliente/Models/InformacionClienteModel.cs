using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class InformacionClienteModel
    {
        public int TN_Valido { get; set; }

        public int TN_Existe { get; set; }

        public string TC_Nombre { get; set; }

        public string TC_Apellidos { get; set; }

        public string TC_Cedula { get; set; }

        public string TC_Email { get; set; }

        public string TC_Telefono { get; set; }

        public string TC_Tarjeta { get; set; }

        public string TC_IdsHabitaciones { get; set; }

        public float TC_Tarifa { get; set; }

        public string TC_URL_IMG { get; set; }

        public string TC_TipoHabitacion { get; set; }

        public TemporadaModel TemporadaActual { get; set; }

        public DateTime TC_FechaInicio { get; set; }

        public DateTime TC_FechaFin { get; set; }

        public int TN_ClienteNuevo { get; set; }

        public string TC_Nombre_Cliente { get; set; }

        public string TC_Lista_Transaccion { get; set; }

        public string TC_PorcentajeOferta { get; set; }

        



    }
}
