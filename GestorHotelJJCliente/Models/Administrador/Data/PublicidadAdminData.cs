using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Data
{
    public class PublicidadAdminData
    {

        public IConfiguration Configuration { get; }

        public PublicidadAdminData(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor



        public PublicidadModel ObtenerPublicidad()
        {
            PublicidadModel publicidadModel = new PublicidadModel();
            

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Obtener_Publicidad";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        publicidadModel.TN_Id_Publicidad = Int32.Parse(productoReader["TN_Id_Publicidad"].ToString());
                        publicidadModel.TC_LinkPublicidad = productoReader["TC_LinkPublicidad"].ToString();
                        publicidadModel.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();

                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return publicidadModel;

        }


        public int ModificarPublicidad(PublicidadModel publicidadModel)
        {
            //PublicidadModel publicidadModel = new PublicidadModel();
            int valido = 1;

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Modificar_Publicidad @TN_Id_Publicidad='{publicidadModel.TN_Id_Publicidad}', @TC_LinkPublicidad='{publicidadModel.TC_LinkPublicidad}', @TC_URL_IMG='{publicidadModel.TC_URL_IMG}'";

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
            return valido;
        }        
    }
}
