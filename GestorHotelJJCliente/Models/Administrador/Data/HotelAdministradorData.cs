using GestorHotelJJCliente.Models.Administrador;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GestorHotelJJCliente.Models.Data
{
    public class HotelAdministradorData
    {

        public IConfiguration Configuration { get; }

        public HotelAdministradorData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<EstadoHotelModel> getEstadosHabitaciones()
        {
            List<EstadoHotelModel> listaRetorno = new List<EstadoHotelModel>();

            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Ver_Estado_Habitaciones";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {

                        EstadoHotelModel listaEstadoHabitacionTemp = new EstadoHotelModel();

                        listaEstadoHabitacionTemp.TN_Id_Habitacion = Int32.Parse(productoReader["TN_Id_Habitacion"].ToString());
                        listaEstadoHabitacionTemp.TC_TipoHabitacion= productoReader["TC_TipoHabitacion"].ToString();
                        listaEstadoHabitacionTemp.TC_Estado = productoReader["TC_Estado"].ToString();
                        listaEstadoHabitacionTemp.TB_Bit = Convert.ToBoolean( productoReader["TB_Bit"].ToString());

                        listaRetorno.Add(listaEstadoHabitacionTemp);
                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;
        }


        public List<EstadoHotelModel> getDisponibilidadHabitaciones(EstadoHotelModel estadoHotelModel)
        {
            List<EstadoHotelModel> listaRetorno = new List<EstadoHotelModel>();

            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Consultar_Disponibilidad @TC_Fecha_Inicio  ='{estadoHotelModel.TC_FechaInicio}', @TC_Fecha_Final  ='{estadoHotelModel.TC_FechaFin}', @TN_Id_TipoHabitacion  ='{estadoHotelModel.TN_Id_TipoHabitacion }'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {

                        EstadoHotelModel listaEstadoHabitacionTemp = new EstadoHotelModel();

                        listaEstadoHabitacionTemp.TN_Id_Habitacion = Int32.Parse(productoReader["TN_Id_Habitacion"].ToString());
                        listaEstadoHabitacionTemp.TC_TipoHabitacion = productoReader["TC_TipoHabitacion"].ToString();
                        listaEstadoHabitacionTemp.TC_Estado = productoReader["TC_Estado"].ToString();

                        listaRetorno.Add(listaEstadoHabitacionTemp);
                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;
        }
        public List<HotelAdminModel> cargarInfoHome()
        {

            List<HotelAdminModel> listaRetorno = new List<HotelAdminModel>();
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Extraer_Home";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        HotelAdminModel listaOfertaTemp = new HotelAdminModel();
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


        public int modificarDisponibilidad(EstadoHotelModel estadoModel)
        {

            List<HotelAdminModel> listaRetorno = new List<HotelAdminModel>();
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Deshabilitar_Habitacion @TN_Id_Habitacion='{estadoModel.TN_Id_Habitacion}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta

                      
                    connection.Close();
                }
            }

            return estadoModel.TN_Id_Habitacion;


        }




        public HotelAdminModel obtieneContactos()
        {

            HotelAdminModel contactos = new HotelAdminModel();
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec sp_contactenos";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {

                        contactos.TC_CorreoElectronico = productoReader["TC_CorreoElectronico"].ToString();
                        contactos.TC_Telefono = productoReader["TC_Telefono"].ToString();

                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return contactos;
        }

        public bool ModificarContactos(HotelAdminModel hotelModel)
        {

            int valido = 0;
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Modificar_Contactos @TC_CorreoElectronico  ='{hotelModel.TC_CorreoElectronico}', @TC_Telefono = '{hotelModel.TC_Telefono}'";
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
