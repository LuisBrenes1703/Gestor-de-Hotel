using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Data
{
    public class ReservaciónData
    {

  

        public IConfiguration Configuration { get; }

        public ReservaciónData(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //Buscar disponibilidad en una habitacion selecionada
        public InformacionClienteModel BuscarDisponibilidadHabitacion(ReservaModel reservaModel)
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




            InformacionClienteModel informacionClienteModel = new InformacionClienteModel();          
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Validar_Reserva @TC_Fecha_Inicio ='{reservaModel.TC_FechaInicio}', @TC_Fecha_Final ='{reservaModel.TC_FechaFin}', @TN_Id_TipoHabitacion ='{reservaModel.TN_Id_TipoHabitacion}',  @TN_Cantidad ='{reservaModel.TN_Cantidad}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();

                    //se extrae el valor de valido de la respuesta que se obtiene de la consulta
                    while (productoReader.Read())
                    {                        
                        informacionClienteModel.TN_Valido = Int32.Parse(productoReader["TN_Valido"].ToString());

                        if (informacionClienteModel.TN_Valido == 1)
                        {
                            informacionClienteModel.TC_TipoHabitacion = productoReader["TC_TipoHabitacion"].ToString();
                            informacionClienteModel.TC_IdsHabitaciones = productoReader["TC_IdsHabitaciones"].ToString();                        
                            informacionClienteModel.TC_Tarifa = float.Parse(productoReader["TC_Tarifa"].ToString());
                            informacionClienteModel.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();
                            informacionClienteModel.TC_PorcentajeOferta = productoReader["TC_PorcentajeOferta"].ToString();

                            informacionClienteModel.TemporadaActual = temporadaModel;

                        }
                        else {
                            informacionClienteModel = null;
                        }
                        
                      
                    }
                    //Se cierra la conexion a la base de datos
                    connection.Close();

                }
            }
            return informacionClienteModel;
        }


        public InformacionClienteModel BuscarDatos(ReservaModel reservaModel)
        {
            InformacionClienteModel informacionClienteModel = new InformacionClienteModel();

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Get_Cliente  @TC_Cedula ='{reservaModel.TC_Cedula}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();

                    //se extrae el valor de valido de la respuesta que se obtiene de la consulta
                    while (productoReader.Read())
                    {

                        informacionClienteModel.TN_Valido = Int32.Parse(productoReader["TN_Valido"].ToString());

                        if (informacionClienteModel.TN_Valido == 1)
                        {

                            informacionClienteModel.TC_Cedula = productoReader["TC_Cedula"].ToString();
                            informacionClienteModel.TC_Nombre = productoReader["TC_Nombre"].ToString();
                            informacionClienteModel.TC_Apellidos = productoReader["TC_Apellidos"].ToString();                           
                            informacionClienteModel.TC_Email = productoReader["TC_Email"].ToString();
                            informacionClienteModel.TC_Telefono = productoReader["TC_Telefono"].ToString();
                            informacionClienteModel.TC_Tarjeta = productoReader["TC_Tarjeta"].ToString();

                        }
                        else
                        {
                            informacionClienteModel = null;
                        }


                    }
                    //Se cierra la conexion a la base de datos
                    connection.Close();

                }
            }
            return informacionClienteModel;
        }



        public InformacionClienteModel RealizarReservacion(InformacionClienteModel informacionClienteModel)
        {


            Guid TC_GUID_Reservacion = Guid.NewGuid();
            System.Diagnostics.Debug.WriteLine("VALOR DEL NUMERO DEL GUID");
            System.Diagnostics.Debug.WriteLine("-------------------------------------*" + TC_GUID_Reservacion);



            InformacionClienteModel cliente = new InformacionClienteModel();

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Realizar_Reserva  @TC_Lista_Id_Habitacion ='{informacionClienteModel.TC_IdsHabitaciones}',  @TC_Cedula ='{informacionClienteModel.TC_Cedula}',  @TC_Nombre ='{informacionClienteModel.TC_Nombre}',  @TC_Apellidos ='{informacionClienteModel.TC_Apellidos}',  @TC_Email ='{informacionClienteModel.TC_Email}',  @TC_Telefono ='{informacionClienteModel.TC_Telefono}',  @TC_Tarjeta ='{informacionClienteModel.TC_Tarjeta}', @TC_Fecha_Inicio ='{informacionClienteModel.TC_FechaInicio}', @TC_Fecha_Final ='{informacionClienteModel.TC_FechaFin}', @TC_GUID_Reservacion ='{TC_GUID_Reservacion}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();

                    //se extrae el valor de valido de la respuesta que se obtiene de la consulta
                    while (productoReader.Read())
                    {


                        cliente.TN_Valido = Int32.Parse(productoReader["TN_Valido"].ToString());

                        if (cliente.TN_Valido == 1)
                        {


                            cliente.TN_ClienteNuevo = Int32.Parse(productoReader["TN_ClienteNuevo"].ToString());
                            cliente.TC_Nombre_Cliente = productoReader["TC_Nombre_Cliente"].ToString();
                            cliente.TC_Lista_Transaccion = productoReader["TC_Lista_Transaccion"].ToString();
                            cliente.TC_Email = productoReader["TC_Email"].ToString();


                        }
                        else
                        {

                            cliente = null;
                        }

                        //Se cierra la conexion a la base de datos

                    }

                    connection.Close();

                }

            }
            return cliente;
        }


    }
}
