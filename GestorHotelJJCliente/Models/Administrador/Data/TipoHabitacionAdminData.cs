using GestorHotelJJCliente.Models.Business;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Data
{
    public class TipoHabitacionAdminData
    {

        public IConfiguration Configuration { get; }

        public TipoHabitacionAdminData(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public List<TipoHabitacionAdminModel> VerTipoHabitacion()
        {
            List<TipoHabitacionAdminModel> listaTipoHabitacionModel = new List<TipoHabitacionAdminModel>();
            List<CaracteristicasModel> listaCaracteristicas = new List<CaracteristicasModel>();

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
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
                        TipoHabitacionAdminModel tipoHabitacionModel = new TipoHabitacionAdminModel();
                        tipoHabitacionModel.TN_Id_TipoHabitacion = Int32.Parse(productoReader["TN_Id_TipoHabitacion"].ToString());
                        tipoHabitacionModel.TC_TipoHabitacion = productoReader["TC_TipoHabitacion"].ToString();
                        tipoHabitacionModel.TC_Descripcion = productoReader["TC_Descripcion"].ToString();
                        tipoHabitacionModel.TC_Tarifa = float.Parse(productoReader["TC_Tarifa"].ToString());
                        tipoHabitacionModel.TN_Cantidad = Int32.Parse(productoReader["TN_Cantidad"].ToString());
                        tipoHabitacionModel.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();

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

            return listaTipoHabitacionModel;
        }


        public bool CrearTipoHabitacion(TipoHabitacionAdminModel tipoHabitacionAdminModel)
        {

            int valido = 0;

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta


                string sqlQuery = $"exec Sp_Crear_Tipo_Habitacion @TC_TipoHabitacion ='{tipoHabitacionAdminModel.TC_TipoHabitacion}', @TC_Descripcion ='{tipoHabitacionAdminModel.TC_Descripcion}', @TC_Tarifa ='{tipoHabitacionAdminModel.TC_Tarifa}', @TN_Cantidad ='{tipoHabitacionAdminModel.TN_Cantidad}', @TC_URL_IMG ='{tipoHabitacionAdminModel.TC_URL_IMG}'";

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


            if (valido == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool ModificarTipoHabitacion(TipoHabitacionAdminModel tipoHabitacionAdminModel)
        {

            int valido = 0; 

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta

             
                string sqlQuery = $"exec Sp_Modificar_Tipo_Habitacion @TN_Id_TipoHabitacion ='{tipoHabitacionAdminModel.TN_Id_TipoHabitacion}', @TC_Descripcion ='{tipoHabitacionAdminModel.TC_Descripcion}', @TC_Tarifa ='{tipoHabitacionAdminModel.TC_Tarifa}', @TC_URL_IMG ='{tipoHabitacionAdminModel.TC_URL_IMG}'";

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


            if (valido == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

    }
}
    
