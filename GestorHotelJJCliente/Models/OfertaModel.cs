using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class OfertaModel
    {
        public int TN_Id_Oferta { get; set; }
        public int  TN_Id_TipoHabitacion { get; set; }
        public float TC_PorcentajeOferta { get; set; }
        public string TC_URL_IMG { get; set; }
    }
}
