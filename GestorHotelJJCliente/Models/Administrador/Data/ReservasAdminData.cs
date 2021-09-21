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
    public class ReservasAdminData
    {
        public IConfiguration Configuration { get; }

        public ReservasAdminData(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor
       
         public List<ReservasAdminModel> getListaReservas()
        {

            List<ReservasAdminModel> listaRetorno = new List<ReservasAdminModel>();
            
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Listar_Reserva";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {

                        ReservasAdminModel reservaTemp = new ReservasAdminModel();
                        reservaTemp.valido = Int32.Parse(productoReader["valido"].ToString());
                        reservaTemp.TC_Fecha = productoReader["TC_Fecha"].ToString();
                        reservaTemp.TN_Id_Reserva = Int32.Parse(productoReader["TN_Id_Reserva"].ToString());
                        reservaTemp.TC_Nombre = productoReader["TC_Nombre"].ToString();
                        reservaTemp.TC_Apellidos = productoReader["TC_Apellidos"].ToString();
                        reservaTemp.TC_Email = productoReader["TC_Email"].ToString();
                        reservaTemp.TC_Tarjeta = productoReader["TC_Tarjeta"].ToString();
                        reservaTemp.TC_Transaccion = productoReader["TC_Transaccion"].ToString();
                        reservaTemp.TC_Fecha_Inicio = productoReader["TC_Fecha_Inicio"].ToString();
                        reservaTemp.TC_Fecha_Final = productoReader["TC_Fecha_Final"].ToString();
                        reservaTemp.TC_TipoHabitacion = productoReader["TC_TipoHabitacion"].ToString();
                        listaRetorno.Add(reservaTemp);

                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;

        }

        public ReservasAdminModel  getReservas(int TN_Id_Reserva)
        {

            ReservasAdminModel reservaTemp = new ReservasAdminModel();

            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_get_Reserva  @TN_Id_Reserva ='{TN_Id_Reserva}' ";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        reservaTemp.valido = Int32.Parse(productoReader["valido"].ToString());
                        reservaTemp.TC_Fecha = productoReader["TC_Fecha"].ToString();
                        reservaTemp.TN_Id_Reserva = Int32.Parse(productoReader["TN_Id_Reserva"].ToString());
                        reservaTemp.TC_Nombre = productoReader["TC_Nombre"].ToString();
                        reservaTemp.TC_Apellidos = productoReader["TC_Apellidos"].ToString();
                        reservaTemp.TC_Email = productoReader["TC_Email"].ToString();
                        reservaTemp.TC_Tarjeta = productoReader["TC_Tarjeta"].ToString();
                        reservaTemp.TC_Transaccion = productoReader["TC_Transaccion"].ToString();
                        reservaTemp.TC_Fecha_Inicio = productoReader["TC_Fecha_Inicio"].ToString();
                        reservaTemp.TC_Fecha_Final = productoReader["TC_Fecha_Final"].ToString();
                        reservaTemp.TC_TipoHabitacion = productoReader["TC_TipoHabitacion"].ToString();

                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return reservaTemp;

        }


        public int EliminarReserva(int TN_Id_Reserva)
        {


            int valido = 0;
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Delete_Reserva  @TN_Id_Reserva ='{TN_Id_Reserva}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();

                    //se extrae el valor de valido de la respuesta que se obtiene de la consulta
                    while (productoReader.Read())
                    {
                        valido = Int32.Parse(productoReader["valido"].ToString());
                    }

                    connection.Close();
                    //Se cierra la conexion a la base de datos

                }

            }


            return valido;
        }





    }
}
