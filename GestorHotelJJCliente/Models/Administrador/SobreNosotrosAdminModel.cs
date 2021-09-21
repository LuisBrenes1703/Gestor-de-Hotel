using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class SobreNosotrosAdminModel
    {
        public int TN_Id_Hotel { get; set; }
        public string TC_SobreNosotros { get; set; }
        public List<FotoModel> TC_Galeria { get; set; }
    }
}
