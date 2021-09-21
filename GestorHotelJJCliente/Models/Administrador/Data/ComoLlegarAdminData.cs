using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Data
{
    public class ComoLlegarAdminData
    {
        public IConfiguration Configuration { get; }

        public ComoLlegarAdminData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<ComoLlegarAdminModel> cargarInfoComoLlegar()
        {

            List<ComoLlegarAdminModel> listaRetorno = new List<ComoLlegarAdminModel>();
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Extraer_Direccion";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        ComoLlegarAdminModel listaOfertaTemp = new ComoLlegarAdminModel();
                        listaOfertaTemp.TN_Id_Direccion = Int32.Parse(productoReader["TN_Id_Direccion"].ToString());
                        listaOfertaTemp.TC_Descripcion = productoReader["TC_Descripcion"].ToString();
                        listaOfertaTemp.TC_LinkGoogleMaps = productoReader["TC_LinkGoogleMaps"].ToString();

                        listaRetorno.Add(listaOfertaTemp);
                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;
        }


        public int modificarPaginaComoLlegar(ComoLlegarAdminModel comoLlegarAdminModel)
        {            
            int valido = 0;
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Modificar_Direccion @TN_Id_Direccion='{comoLlegarAdminModel.TN_Id_Direccion}', @TC_Descripcion='{comoLlegarAdminModel.TC_Descripcion}', @TC_LinkGoogleMaps='{comoLlegarAdminModel.TC_LinkGoogleMaps}'";
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
