using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Administrador.Data
{
    public class FacilidadesAdminData
    {

        public IConfiguration Configuration { get; }

        public FacilidadesAdminData(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        //Listar Facilidades para poder modificar y eliminar
        public List<FacilidadesAdminModel> getListarFacilidad()
        {

            List<FacilidadesAdminModel> listaRetorno = new List<FacilidadesAdminModel>();
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
                        FacilidadesAdminModel listaFacilidadTemp = new FacilidadesAdminModel();
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


        public bool ModificarFacilidades(FacilidadesAdminModel facilidadesAdminModel)
        {

            int valido = 0;

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta


                string sqlQuery = $"exec Sp_Modificar_Facilidades @TN_Id_Facilidad ='{facilidadesAdminModel.TN_Id_Facilidad}', @TC_Descripcion_Facilidad ='{facilidadesAdminModel.TC_Descripcion_Facilidad}', @TC_URL_IMG ='{facilidadesAdminModel.TC_URL_IMG}'";

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


        public int EliminarFacilidad(string TN_Id_Facilidad)
        {

            int valido = 0;
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //se escribe la consulta
                string sqlQuery = $"exec Sp_Eliminar_Facilidad @TN_Id_Facilidad ='{TN_Id_Facilidad}'";
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
