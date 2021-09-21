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
    public class OfertaAdminData
    {
        public IConfiguration Configuration { get; }

        public OfertaAdminData(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor
       
         public OfertaAdminModel cargarOferta(OfertaAdminModel ofertaAdminModel)
        {

            OfertaAdminModel OfertaTemp = new OfertaAdminModel();
            
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Listar_Oferta_Especifico  @TN_Id_Oferta ='{ofertaAdminModel.TN_Id_Oferta}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                       
                        OfertaTemp.TN_Id_Oferta = Int32.Parse(productoReader["TN_Id_Oferta"].ToString());                      
                        OfertaTemp.TN_Id_TipoHabitacion = Int32.Parse(productoReader["TN_Id_TipoHabitacion"].ToString());
                        OfertaTemp.TC_Nombre_Oferta = productoReader["TC_Oferta"].ToString();
                        OfertaTemp.TC_PorcentajeOferta = float.Parse(productoReader["TC_PorcentajeOferta"].ToString());
                        OfertaTemp.TC_URL_IMG = productoReader["TC_URL_IMG"].ToString();

                        DateTime dI = DateTime.Parse(productoReader["TC_Fecha_Inicio"].ToString());
                        OfertaTemp.TC_FechaInicio = dI.ToString("yyyy-MM-dd");

                        DateTime dF = DateTime.Parse(productoReader["TC_Fecha_Final"].ToString());
                        OfertaTemp.TC_FechaFin = dF.ToString("yyyy-MM-dd");


                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return OfertaTemp;
        }

        public int agregarOferta(OfertaAdminModel ofertaAdminModel)
        {

            int valido = 0;
            string rutaImagen = "/assets/img/oferta/" + ofertaAdminModel.TC_Nombre_Oferta + ".jpg";

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Agregar_Oferta  @TN_Id_TipoHabitacion ='{ofertaAdminModel.TN_Id_TipoHabitacion}',  @TC_Fecha_Inicio ='{ofertaAdminModel.TC_Fecha_Inicio}',  @TC_Fecha_Fin ='{ofertaAdminModel.TC_Fecha_Fin}',  @TC_PorcentajeOferta ='{ofertaAdminModel.TC_PorcentajeOferta}', @TC_Nombre_Oferta ='{ofertaAdminModel.TC_Nombre_Oferta}',   @TC_URL_IMG ='{rutaImagen}'";
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



        public List<OfertaAdminModel> cargarIdNombresOfertas()
        {

            List<OfertaAdminModel> listaRetorno = new List<OfertaAdminModel>();
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Listar_Ofertas_Nombre_Id";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();
                    //Se hace lectura de lo que nos retorno la consulta
                    while (productoReader.Read())
                    {
                        OfertaAdminModel OfertaTemp = new OfertaAdminModel();
                        OfertaTemp.TN_Id_Oferta = Int32.Parse(productoReader["TN_Id_Oferta"].ToString());
                        OfertaTemp.TC_Nombre_Oferta = productoReader["TC_Oferta"].ToString();

                        listaRetorno.Add(OfertaTemp);

                    } // while
                      //Se cierra la conexion a la base de datos
                    connection.Close();
                }
            }

            return listaRetorno;
        }


        public OfertaAdminModel modificarOferta(OfertaAdminModel ofertaAdminModel)
        {
            OfertaAdminModel ofertaAdminModelSalida = new OfertaAdminModel();
           
            string rutaImagen = "/assets/img/oferta/" + ofertaAdminModel.TC_Nombre_Oferta + ".jpg";

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Modificar_Oferta  @TN_Id_Oferta ='{ofertaAdminModel.TN_Id_Oferta}', @TN_Id_TipoHabitacion ='{ofertaAdminModel.TN_Id_TipoHabitacion}',  @TC_Fecha_Inicio ='{ofertaAdminModel.TC_Fecha_Inicio}',  @TC_Fecha_Fin ='{ofertaAdminModel.TC_Fecha_Fin}',  @TC_PorcentajeOferta ='{ofertaAdminModel.TC_PorcentajeOferta}', @TC_Nombre_Oferta  ='{ofertaAdminModel.TC_Nombre_Oferta}', @TC_URL_IMG ='{rutaImagen}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Se abre y se ejecuta la consulta
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader productoReader = command.ExecuteReader();

                    //se extrae el valor de valido de la respuesta que se obtiene de la consulta
                    while (productoReader.Read())
                    {
                        ofertaAdminModelSalida.valido = Int32.Parse(productoReader["valido"].ToString());
                        ofertaAdminModelSalida.TC_Nombre_Oferta = productoReader["TC_Oferta_Antiguo"].ToString();
                    }

                    connection.Close();
                    //Se cierra la conexion a la base de datos

                }

            }

            if (ofertaAdminModelSalida.valido ==1 && ofertaAdminModel.imagenOferta != null) {

                string ruta = @"wwwroot\assets\img\oferta\"+ ofertaAdminModelSalida.TC_Nombre_Oferta+".jpg";
                File.Delete(ruta);
            
            }

            return ofertaAdminModelSalida;
        }

        public int EliminarOferta(OfertaAdminModel ofertaAdminModel)
        {

            int valido = 0;
            string nombreImagen = "";
            //string rutaImagen = "/assets/img/oferta/" + ofertaAdminModel.TC_Nombre_Oferta + ".jpg";

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Borrar_Oferta  @TN_Id_Oferta ='{ofertaAdminModel.TN_Id_Oferta}'";
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
                        nombreImagen = productoReader["TC_Oferta_Antiguo"].ToString();
                    }

                    connection.Close();
                    //Se cierra la conexion a la base de datos

                }

            }


            if (valido == 1)
            {

                string ruta = @"wwwroot\assets\img\oferta\" + nombreImagen + ".jpg";
                File.Delete(ruta);

            }

            return valido;
        }

        


    }
}
