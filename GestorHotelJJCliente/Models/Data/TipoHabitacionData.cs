using GestorHotelJJCliente.Models.Business;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Data
{
    public class TipoHabitacionData
    {

        public IConfiguration Configuration { get; }

        public TipoHabitacionData(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public List<TipoHabitacionModel> ObtenerTipoHabitacion()
        {
            TemporadaModel temporadaModel = new TemporadaModel();
            List<TipoHabitacionModel> listaTipoHabitacionModel = new List<TipoHabitacionModel>();

            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                
                string sqlQuery = $"exec Sp_Extraer_Temporada";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {                        
                        temporadaModel.TN_Id_Temporada = Int32.Parse(productoReader["TN_Id_Temporada"].ToString());
                        temporadaModel.TC_Temporada = productoReader["TC_Temporada"].ToString();
                        temporadaModel.TC_PorcentajeTemporada = productoReader["TC_PorcentajeTemporada"].ToString();
                        //temporadaModel.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();

                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }


            List<CaracteristicasModel> listaCaracteristicas = new List<CaracteristicasModel>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta

                string sqlQuery = $"exec Sp_Extraer_Caracteristica_TipoHabitacion";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        CaracteristicasModel caracteristicaModel = new CaracteristicasModel();
                        caracteristicaModel.TN_Id_Caracteristica = Int32.Parse(productoReader["TN_Id_Caracteristica"].ToString());
                        caracteristicaModel.TC_Caracteristica = productoReader["TC_Caracteristica"].ToString();
                        caracteristicaModel.TN_Id_TipoHabitacion = Int32.Parse(productoReader["TN_Id_TipoHabitacion"].ToString());
                        listaCaracteristicas.Add(caracteristicaModel);
                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta

                string sqlQuery = $"exec Sp_Extraer_TipoHabitacion";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        TipoHabitacionModel tipoHabitacionModel = new TipoHabitacionModel();
                        tipoHabitacionModel.TN_Id_TipoHabitacion = Int32.Parse(productoReader["TN_Id_TipoHabitacion"].ToString());
                        tipoHabitacionModel.TC_TipoHabitacion = productoReader["TC_TipoHabitacion"].ToString();
                        tipoHabitacionModel.TC_Descripcion = productoReader["TC_Descripcion"].ToString();
                        tipoHabitacionModel.TC_Tarifa = float.Parse(productoReader["TC_Tarifa"].ToString());
                        tipoHabitacionModel.TN_Cantidad = Int32.Parse(productoReader["TN_Cantidad"].ToString());
                        tipoHabitacionModel.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();
                        tipoHabitacionModel.TC_PorcentajeOferta = productoReader["TC_PorcentajeOferta"].ToString();                        

                        tipoHabitacionModel.TemporadaActual = temporadaModel;

                        listaTipoHabitacionModel.Add(tipoHabitacionModel);
                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }



            for (int i = 0; i < listaTipoHabitacionModel.Count; i++)
            {
                List<CaracteristicasModel> listaCaracteristicasTipoHabitacion = new List<CaracteristicasModel>();
                for (int j = 0; j < listaCaracteristicas.Count; j++)
                {
                    if (listaTipoHabitacionModel[i].TN_Id_TipoHabitacion == listaCaracteristicas[j].TN_Id_TipoHabitacion)
                    {
                        listaCaracteristicasTipoHabitacion.Add(listaCaracteristicas[j]);
                    }

                }
                listaTipoHabitacionModel[i].listCaracteristicas = listaCaracteristicasTipoHabitacion;

            }

            limpiarHabitaciones(); 

            return listaTipoHabitacionModel;
        }


        public void limpiarHabitaciones()
        {
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta

                string sqlQuery = $"exec Sp_Validar_Tiempos";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {

                    } // while
                    //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }
        }
    }
}
