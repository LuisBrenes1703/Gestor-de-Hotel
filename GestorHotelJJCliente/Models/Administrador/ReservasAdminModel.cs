using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class ReservasAdminModel
    {
        public int valido { get; set; }
        public string TC_Fecha { get; set; }
        public int TN_Id_Reserva { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Apellidos { get; set; }
        public string TC_Email { get; set; }
        public string TC_Tarjeta { get; set; }
        public string TC_Transaccion { get; set; }
        public string TC_Fecha_Inicio { get; set; }
        public string TC_Fecha_Final { get; set; }
        public string TC_TipoHabitacion { get; set; }

    }
}
