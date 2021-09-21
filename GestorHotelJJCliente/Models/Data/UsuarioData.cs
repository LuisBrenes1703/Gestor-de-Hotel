using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestorHotelJJCliente.Models.Data
{
    public class UsuarioData
    {

        public IConfiguration Configuration { get; }

        public UsuarioData(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor


        //Verificar si el usuario existe, en caso de que si se debe 
        public UsuarioModel LoginUsuario(UsuarioModel usuario)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            int valido = 0;
            //se crea la conexion
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec Sp_Login_Usuario @TC_Usuario ='{usuario.TC_Usuario}', @TC_Contrasenna='{usuario.TC_Contrasenna}'";
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
                        //Si valido =1 se extraen los demas valores devueltos, en este caso se devuelve el nombre del usuario,
                        //y cual id de permiso posee el usuario
                        if (valido == 1)
                        {
                            usuarioModel.TC_Usuario = productoReader["TC_Usuario"].ToString();
                            usuarioModel.TN_Id_Permiso = Int32.Parse(productoReader["TN_Id_Permiso"].ToString());
                        }


                    }
                    // se cierra la conexion a la base de datos
                    connection.Close();

                }
            }
            //si el valor de valido es 1 se hace el retun hacia el model de usuario si no retorna null
            if (valido == 1)
            {
                return usuarioModel;
            }
            else
            {
                return null;
            }

        }

    }
}
