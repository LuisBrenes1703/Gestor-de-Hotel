using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class OfertaAdminBusiness
    {
        public IConfiguration Configuration { get; }
        public OfertaAdminBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public OfertaAdminModel cargarOferta(OfertaAdminModel ofertaAdminModel)
        {
            OfertaAdminData ofertaAdminData = new OfertaAdminData(Configuration);
            return ofertaAdminData.cargarOferta(ofertaAdminModel);
        }


        public int agregarOferta(OfertaAdminModel ofertaAdminModel)
        {
            OfertaAdminData ofertaAdminData = new OfertaAdminData(Configuration);
            return ofertaAdminData.agregarOferta(ofertaAdminModel);
        }

        public OfertaAdminModel modificarOferta(OfertaAdminModel ofertaAdminModel)
        {
            OfertaAdminData ofertaAdminData = new OfertaAdminData(Configuration);
            return ofertaAdminData.modificarOferta(ofertaAdminModel);
        }

        public List<OfertaAdminModel> cargarIdNombresOfertas()
        {
            OfertaAdminData ofertaAdminData = new OfertaAdminData(Configuration);
            return ofertaAdminData.cargarIdNombresOfertas();
        }

        public int EliminarOferta(OfertaAdminModel ofertaAdminModel)
        {
            OfertaAdminData ofertaAdminData = new OfertaAdminData(Configuration);
            return ofertaAdminData.EliminarOferta(ofertaAdminModel);
        }

        


    }
}
