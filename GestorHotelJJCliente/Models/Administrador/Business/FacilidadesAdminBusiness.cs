using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class FacilidadesAdminBusiness
    {
        public IConfiguration Configuration { get; }

        public FacilidadesAdminBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public List<FacilidadesAdminModel> getListarFacilidad()
        {
            FacilidadesAdminData dataFacilidad = new FacilidadesAdminData(Configuration);
            return dataFacilidad.getListarFacilidad();
        }

        public bool ModificarFacilidades(FacilidadesAdminModel facilidadesAdminModel)
        {

            FacilidadesAdminData facilidadesAdminData = new FacilidadesAdminData(Configuration);

            return facilidadesAdminData.ModificarFacilidades(facilidadesAdminModel);

        }

        
        public int EliminarFacilidad(string TN_Id_Facilidad)
        {

            FacilidadesAdminData facilidadData = new FacilidadesAdminData(Configuration);

            return facilidadData.EliminarFacilidad(TN_Id_Facilidad);

        }
    }
}
