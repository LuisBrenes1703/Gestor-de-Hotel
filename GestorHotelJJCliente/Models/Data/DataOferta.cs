using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestorHotelJJCliente.Models.Data
{
    public class DataOferta
    {
        public IConfiguration Configuration { get; }

        public DataOferta(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor
        public List<OfertaModel> cargarOferta()
        {

            List<OfertaModel> listaRetorno = new List<OfertaModel>();
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Listar_Oferta";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        OfertaModel listaOfertaTemp = new OfertaModel();
                        listaOfertaTemp.TN_Id_Oferta = Int32.Parse(productoReader["TN_Id_Oferta"].ToString());
                        listaOfertaTemp.TN_Id_TipoHabitacion = Int32.Parse(productoReader["TN_Id_TipoHabitacion"].ToString());
                        listaOfertaTemp.TC_PorcentajeOferta = float.Parse(productoReader["TC_PorcentajeOferta"].ToString());
                        listaOfertaTemp.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();

                        listaRetorno.Add(listaOfertaTemp);
                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;
        }
    }
}
