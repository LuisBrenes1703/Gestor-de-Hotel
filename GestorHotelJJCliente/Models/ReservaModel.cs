using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class ReservaModel
    {

        public DateTime TC_FechaInicio { get; set; }

        public DateTime TC_FechaFin { get; set; }

        public int TN_Cantidad { get; set; }

        public int TN_Id_TipoHabitacion { get; set; }

        public int TC_Cedula { get; set; }

        
    }
}
