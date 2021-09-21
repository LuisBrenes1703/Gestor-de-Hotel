using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class PublicidadModel
    {
        public int  TN_Id_Publicidad { get; set; }
        public string TC_LinkPublicidad { get; set; }
        public string TC_URL_IMG { get; set; }
        public IFormFile imagenPublicidad { get; set; }
    }
}
