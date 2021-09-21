using GestorHotelJJCliente.Models.Administrador.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Business
{
    public class SobreNosotrosAdminBusiness
    {
        public IConfiguration Configuration { get; }

        public SobreNosotrosAdminBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SobreNosotrosAdminModel VerSobreNosotrosClientesView()
        {
            SobreNosotrosAdminData sobreNosotrosData = new SobreNosotrosAdminData(this.Configuration);
            SobreNosotrosAdminModel sobreNosotrosModel = new SobreNosotrosAdminModel();
            sobreNosotrosModel = sobreNosotrosData.ModificarSobreNosotrosAdmin();
            return sobreNosotrosModel;
        }
        public int ModificarTexto(int TN_Id_Hotel, string TC_SobreNosotros)
        {
            SobreNosotrosAdminData sobreNosotrosData = new SobreNosotrosAdminData(this.Configuration);
            int valido = 0;
            valido = sobreNosotrosData.ModificarTexto(TN_Id_Hotel, TC_SobreNosotros);
            return valido;
        }


        public int AgregarFoto(FotoModel fotoModel)
        {
            SobreNosotrosAdminData sobreNosotrosData = new SobreNosotrosAdminData(this.Configuration);
            return sobreNosotrosData.AgregarFoto(fotoModel);
        }

        public int EliminarFotoGaleria(FotoModel fotoModel)
        {
            SobreNosotrosAdminData sobreNosotrosData = new SobreNosotrosAdminData(this.Configuration);
            return sobreNosotrosData.EliminarFotoGaleria(fotoModel);
        }

        


    }
}
