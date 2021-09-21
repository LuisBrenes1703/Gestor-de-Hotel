using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GestorHotelJJCliente.Models.Administrador.Data
{
    public class SobreNosotrosAdminData
    {

        public IConfiguration Configuration { get; }

        public SobreNosotrosAdminData(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public SobreNosotrosAdminModel ModificarSobreNosotrosAdmin()
        {
            SobreNosotrosAdminModel sobreNosotrosModel = new SobreNosotrosAdminModel();
            List<FotoModel> listaGaleria = new List<FotoModel>();

            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"exec Sp_ver_sobre_nosotros;";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            sobreNosotrosModel.TC_SobreNosotros = dataReader["TC_SobreNosotros"].ToString();
                            sobreNosotrosModel.TN_Id_Hotel = Int32.Parse(dataReader["TN_Id_Hotel"].ToString());
                        }

                    }
                }
                connection.Close();
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string sql = $"exec Sp_ver_galeria;";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            FotoModel fotoModel = new FotoModel();
                            fotoModel.TN_Id_Galeria = Int32.Parse(dataReader["TN_Id_Galeria"].ToString());
                            fotoModel.TC_URL_IMG = dataReader["TC_URL_IMG"].ToString();

                            listaGaleria.Add(fotoModel);

                        }

                        sobreNosotrosModel.TC_Galeria = listaGaleria;

                    }
                }
                connection.Close();
            }

            return sobreNosotrosModel;
        }
        public int ModificarTexto(int TN_Id_Hotel, string TC_SobreNosotros)
        {
            int valido = 0;
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"exec Sp_modificar_sobreNosotros @TN_Id_Hotel ='{TN_Id_Hotel}', @TC_SobreNosotros ='{TC_SobreNosotros}'";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            valido = Int32.Parse(dataReader["valido"].ToString());
                        }

                    }
                }
                connection.Close();
            }
            return valido;
        }


        public int AgregarFoto(FotoModel fotoModel)
        {
            int valido = 0;
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"exec Sp_agregar_fotoGaleria @TC_URL_IMG ='{fotoModel.TC_URL_IMG}'";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            valido = Int32.Parse(dataReader["valido"].ToString());
                        }

                    }
                }
                connection.Close();
            }
            return valido;
        }


        public int EliminarFotoGaleria(FotoModel fotoModel)
        {
            int valido = 0;
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"exec Sp_eliminar_fotoGaleria @TN_Id_Galeria ='{fotoModel.TN_Id_Galeria}'";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            valido = Int32.Parse(dataReader["valido"].ToString());
                        }

                    }
                }
                connection.Close();
            }
            return valido;
        }
        



    }
}
