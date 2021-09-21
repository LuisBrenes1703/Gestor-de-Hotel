using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GestorHotelJJCliente.Models;
using Microsoft.Extensions.Configuration;

namespace GestorHotelJJCliente.Models.Data
{
    public class DataFacilidades
    {
        public IConfiguration Configuration { get; }

        public DataFacilidades(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        //Listar Facilidades para poder modificar y eliminar
        public List<FacilidadModel> getListarFacilidad()
        {

            List<FacilidadModel> listaRetorno = new List<FacilidadModel>();
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_listar_Facilidad";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();

                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        FacilidadModel listaFacilidadTemp = new FacilidadModel();
                        listaFacilidadTemp.TN_Id_Facilidad = Int32.Parse(productoReader["TN_Id_Facilidad"].ToString());
                        listaFacilidadTemp.TC_Nombre_Facilidad = productoReader["TC_Nombre"].ToString();
                        listaFacilidadTemp.TC_Descripcion_Facilidad = productoReader["TC_Descripcion"].ToString();                     
                        listaFacilidadTemp.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();
                        listaRetorno.Add(listaFacilidadTemp);
                    } // while

                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;
        }



      



    


      


    }


}

