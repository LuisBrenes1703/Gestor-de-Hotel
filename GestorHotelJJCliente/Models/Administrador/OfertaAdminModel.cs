using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class OfertaAdminModel
    {
        public int valido { get; set; }
        public int TN_Id_Oferta { get; set; }
        public string TC_Nombre_Oferta { get; set; }
        public string TC_URL_IMG { get; set; }
        public int TN_Id_TipoHabitacion { get; set; }
        public string TC_FechaInicio { get; set; }
        public string TC_FechaFin { get; set; }
        public DateTime TC_Fecha_Inicio { get; set; }
        public DateTime TC_Fecha_Fin { get; set; }
        public float TC_PorcentajeOferta { get; set; }
        public IFormFile imagenOferta { get; set; }

    }
}
