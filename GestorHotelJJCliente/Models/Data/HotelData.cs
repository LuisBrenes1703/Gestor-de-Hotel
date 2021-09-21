using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GestorHotelJJCliente.Models.Data
{
    public class HotelData
    {

        public IConfiguration Configuration { get; }

        public HotelData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public HotelModel VerSobreNosotrosClientesView()
        {
            HotelModel hotelModel = new HotelModel();
            List<FotoModel> listaGaleria = new List<FotoModel>();

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"exec sp_SobreNosotros;";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            hotelModel.TC_SobreNosotros = dataReader["TC_SobreNosotros"].ToString();

                        }

                    }
                }
                connection.Close();
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string sql = $"exec sp_Galeria;";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            FotoModel fotoModel = new FotoModel();
                            fotoModel.TC_URL_IMG = dataReader["TC_URL_IMG"].ToString();

                            listaGaleria.Add(fotoModel);

                        }

                        hotelModel.TC_Galeria = listaGaleria;

                    }
                }
                connection.Close();
            }

            return hotelModel;
        }


        public List<HotelModel> cargarInicio()
        {

            List<HotelModel> listaRetorno = new List<HotelModel>();
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Inicio_Hotel";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        HotelModel listaOfertaTemp = new HotelModel();
                        listaOfertaTemp.TN_Id_Hotel = Int32.Parse(productoReader["TN_Id_Hotel"].ToString());
                        listaOfertaTemp.TC_Inicio = productoReader["TC_Inicio"].ToString();
                        listaOfertaTemp.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();

                        listaRetorno.Add(listaOfertaTemp);
                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;
        }


        public HotelModel VerContactenosClientesView()
        {
            HotelModel hotelModel = new HotelModel();
         

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"exec sp_contactenos;";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            hotelModel.TC_CorreoElectronico = dataReader["TC_CorreoElectronico"].ToString();
                            hotelModel.TC_Telefono = dataReader["TC_Telefono"].ToString();

                        }

                    }
                }
                connection.Close();
            }

            return hotelModel;

        }



        public DireccionModel VerComoLlegarClientesView()
        {
            DireccionModel direccionModel = new DireccionModel();


            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"exec sp_ComoLlegar;";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            direccionModel.TC_Descripcion = dataReader["TC_Descripcion"].ToString();
                            direccionModel.TC_LinkGoogleMaps = dataReader["TC_LinkGoogleMaps"].ToString();

                        }

                    }
                }
                connection.Close();
            }

            return direccionModel;

        }

    }
}
