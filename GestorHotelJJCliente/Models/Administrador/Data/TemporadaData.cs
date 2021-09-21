using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Data
{
    public class TemporadaData
    {

        public IConfiguration Configuration { get; }

        public TemporadaData(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        public int CrearTemporada(TemporadaAdminModel tempModel)
        {
           
            int valido = 0;
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //se escribe la consulta
                string sqlQuery = $"exec Sp_Crear_Temporada @TC_Temporada ='{tempModel.TC_Temporada}', @TC_PorcentajeTemporada ='{tempModel.TC_PorcentajeTemporada}', @fechaInicio ='{tempModel.TC_Fecha_Inicio}', @fechaFin ='{tempModel.TC_Fecha_Final}'";
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

                    }
                    // se cierra la conexion a la base de datos
                    connection.Close();

                }
            }
            //si el valor de valido es 1 se hace el retun hacia el model de usuario si no retorna null

              return valido;

        }

        public List<TemporadaAdminModel> mostrarTemporada()
        {
           
            List<TemporadaAdminModel> temp = new List<TemporadaAdminModel>();

            int valido = 0;
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //se escribe la consulta
                string sqlQuery = $"exec Sp_Mostrar_Temporadas";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();

                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        TemporadaAdminModel temporadaModel = new TemporadaAdminModel();
                        
                        temporadaModel.TN_Id_Temporada = Int32.Parse(productoReader["TN_Id_Temporada"].ToString());
                        temporadaModel.TC_Temporada = productoReader["TC_Temporada"].ToString();
                        temporadaModel.TC_PorcentajeTemporada = productoReader["TC_PorcentajeTemporada"].ToString();
                        
                        DateTime dI = DateTime.Parse(productoReader["TC_Fecha_Inicio"].ToString());
                        temporadaModel.TC_Fecha_Inicio = dI.ToString("yyyy-MM-dd");

                        DateTime dF = DateTime.Parse(productoReader["TC_Fecha_Final"].ToString());
                        temporadaModel.TC_Fecha_Final = dF.ToString("yyyy-MM-dd");
                        

                        valido = Int32.Parse(productoReader["valido"].ToString());

                       
                        temp.Add(temporadaModel);


                    }
                    // se cierra la conexion a la base de datos
                    connection.Close();

                }
            }
            //si el valor de valido es 1 se hace el retun hacia el model de usuario si no retorna null

            return temp;

        }


        public int ModificarTemporada(TemporadaAdminModel tempModel)
        {

            int valido = 0;
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //se escribe la consulta
                string sqlQuery = $"exec Sp_Modificar_Temporada @TN_Id_Temporada ='{tempModel.TN_Id_Temporada}',@TC_Temporada ='{tempModel.TC_Temporada}', @TC_PorcentajeTemporada ='{tempModel.TC_PorcentajeTemporada}', @fechaInicio ='{tempModel.TC_Fecha_Inicio}', @fechaFin ='{tempModel.TC_Fecha_Final}'";
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

                    }
                    // se cierra la conexion a la base de datos
                    connection.Close();

                }
            }
            //si el valor de valido es 1 se hace el retun hacia el model de usuario si no retorna null

            return valido;

        }

        public int EliminarTemporada(string TN_Id_Temporada)
        {

            int valido = 0;
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //se escribe la consulta
                string sqlQuery = $"exec Sp_Eliminar_Temporada @TN_Id_Temporada ='{TN_Id_Temporada}'";
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

                    }
                    // se cierra la conexion a la base de datos
                    connection.Close();

                }
            }
            //si el valor de valido es 1 se hace el retun hacia el model de usuario si no retorna null
           
            return valido;

        }


    }
}
