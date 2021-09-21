using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class HotelModel
    {
   
        public int TN_Id_Hotel { get; set; }

        public string TC_Inicio { get; set; }

        public string TC_SobreNosotros { get; set; }

        public string TC_Telefono { get; set; }

        public string TC_CorreoElectronico { get; set; }

        public string TC_URL_IMG { get; set; }

        public List<FotoModel> TC_Galeria { get; set; }
    }
}
