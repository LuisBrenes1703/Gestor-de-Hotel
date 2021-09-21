using GestorHotelJJCliente.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Business
{
    public class BusinessUsuario
    {
        public IConfiguration Configuration { get; }

        public BusinessUsuario(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public UsuarioModel LoginUsuario(UsuarioModel usuario)
        {

            UsuarioData dataUsuario = new UsuarioData(Configuration);
            return dataUsuario.LoginUsuario(usuario);

        }
    }
}
