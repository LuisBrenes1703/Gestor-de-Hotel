using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class TipoHabitacionAdminModel
    {
        public int TN_Id_TipoHabitacion { get; set; }

        public string TC_TipoHabitacion { get; set; }

        public string TC_Descripcion { get; set; }

        public float TC_Tarifa { get; set; }

        public int TN_Cantidad { get; set; }

        public string TC_URL_IMG { get; set; }

        public TemporadaModel TemporadaActual { get; set; }

        public List<CaracteristicasModel> listCaracteristicas { get; set; }
    }
}
