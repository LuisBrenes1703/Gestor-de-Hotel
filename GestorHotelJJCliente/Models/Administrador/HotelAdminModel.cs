
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class HotelAdminModel
    {
        public int TN_Id_Hotel { get; set; }

        public string TC_Inicio { get; set; }

        public string TC_URL_IMG { get; set; }

        public string TC_Telefono { get; set; }

        public string TC_CorreoElectronico { get; set; }

        public IFormFile imagenHome { get; set; }

    }
}
