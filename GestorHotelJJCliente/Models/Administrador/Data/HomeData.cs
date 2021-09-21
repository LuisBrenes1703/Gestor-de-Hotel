using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Data
{
    public class HomeData
    {
        public IConfiguration Configuration { get; }

        public HomeData(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public int modificarPaginaHome(HotelAdminModel hotelAdminModel)
        {
            string rutaImagen = "/assets/img/hotel/Legendary.jpg";
            int valido = 0;
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Modificar_Hotel @TN_Id_Hotel='{hotelAdminModel.TN_Id_Hotel}', @TC_Inicio='{hotelAdminModel.TC_Inicio}', @TC_URL_IMG ='{rutaImagen}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        valido = Int32.Parse(productoReader["valido"].ToString());

                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }


            if (valido == 1 && hotelAdminModel.imagenHome != null)
            {

                //string ruta = @"wwwroot\assets\img\hotel\" + hotelAdminModel.TC_Nombre_Hotel + ".jpg";
                string ruta = @"wwwroot\assets\img\hotel\Legendary.jpg";
                File.Delete(ruta);

            }

            return valido;
        }

    }
}
