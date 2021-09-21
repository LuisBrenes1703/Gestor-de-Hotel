using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestorHotelJJCliente.Models.Data
{
    public class DataPublicidad
    {
        public IConfiguration Configuration { get; }

        public DataPublicidad(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor
        public List<PublicidadModel> cargarPublicidad()
        {

            List<PublicidadModel> listaRetorno = new List<PublicidadModel>();
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Listar_Publicidad";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        PublicidadModel listaPublicidadTemp = new PublicidadModel();
                        listaPublicidadTemp.TN_Id_Publicidad = Int32.Parse(productoReader["TN_Id_Publicidad"].ToString());
                        listaPublicidadTemp.TC_LinkPublicidad = productoReader["TC_LinkPublicidad"].ToString();
                        listaPublicidadTemp.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();


                        listaRetorno.Add(listaPublicidadTemp);
                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;
        }
    }
}
