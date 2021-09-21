using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models
{
    public class UsuarioModel
    {
		public int TN_Id_Usuario { get; set; }
		public string TC_Usuario { get; set; }
		public string TC_Contrasenna { get; set; }
		public int TB_Activo { get; set; }
		public int TN_Id_Puesto { get; set;}
		public int TN_Id_Permiso { get; set; }
		public int TB_Eliminado { get; set; }

	}
}
