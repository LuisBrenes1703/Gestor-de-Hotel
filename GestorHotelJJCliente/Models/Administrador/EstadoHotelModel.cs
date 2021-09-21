using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class EstadoHotelModel
    {


        public DateTime TC_FechaInicio { get; set; }

        public DateTime TC_FechaFin { get; set; }

        public int TN_Id_TipoHabitacion { get; set; }

        public int TN_Id_Habitacion { get; set; }

        public string TC_TipoHabitacion { get; set; }

        public string TC_Estado { get; set; }

        public int TN_TipoOperacion { get; set; }
        public Boolean TB_Bit { get; set; }


    }
}
