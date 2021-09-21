using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class PublicidadAdminBusiness
    {

        public IConfiguration Configuration { get; }

        public PublicidadAdminBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor



        public PublicidadModel ObtenerPublicidad()
        {

            PublicidadAdminData facilidadesAdminData = new PublicidadAdminData(Configuration);

            return facilidadesAdminData.ObtenerPublicidad();

        }

        public int ModificarPublicidad(PublicidadModel publicidadModel)
        {
            PublicidadAdminData facilidadesAdminData = new PublicidadAdminData(Configuration);
            return facilidadesAdminData.ModificarPublicidad(publicidadModel);
        }
    }
}
