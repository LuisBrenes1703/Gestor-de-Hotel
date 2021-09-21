
using GestorHotelJJCliente.Models;
using GestorHotelJJCliente.Models.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace GestorHotelJJCliente.Controllers
{
    public class ReservacionController : Controller
    {

        public IConfiguration Configuration { get; }

        public ReservacionController(IConfiguration configuration)
        {
            Configuration = configuration;
        } // constructor

        public IActionResult BuscarDisponibilidadView()
        {

            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;

            TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
            listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaHabitacion;

            return View("/Views/VistaReservas/BuscarDisponibilidadView.cshtml");
        }



        [HttpPost]

        public IActionResult InformacionClienteReservaView(ReservaModel reservaModel)
        {
            //return new JsonResult(reservaModel.TC_FechaInicio  + "" +  reservaModel.TN_Cantidad + "" + reservaModel.TC_FechaFin + "" + reservaModel.TN_Id_TipoHabitacion);



            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;


            TipoHabitacionBusiness tipoHabitacionBusiness = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaTipoHabitacion = new List<TipoHabitacionModel>();
            listaTipoHabitacion = tipoHabitacionBusiness.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaTipoHabitacion;


            //reservaModel.TN_Id_TipoHabitacion = 1;

            ReservacionBusiness reservacionBusiness = new ReservacionBusiness(Configuration);
            InformacionClienteModel informacionClienteModel = new InformacionClienteModel();


            ViewBag.fechas = null;
            ViewBag.dispobilidad = null;

            var Date = DateTime.Now.ToString("dd-MM-yyyy");
            DateTime hoy = DateTime.Today;

            //return new JsonResult(fInicio.Year + " - " + reservaModel.TC_FechaInicio.Year);
            if (hoy >= reservaModel.TC_FechaInicio || reservaModel.TC_FechaInicio >= reservaModel.TC_FechaFin)
            {

                ViewBag.fechas = "Error con el rango de fechas";
                return View("/Views/VistaReservas/BuscarDisponibilidadView.cshtml");

            }





            informacionClienteModel = reservacionBusiness.BuscarDisponibilidadHabitacion(reservaModel);

            if (informacionClienteModel == null)
            {

                ViewBag.dispobilidad = "En este rango fechas no existe disponiblidad de esa cantidad de habitaciones.";
                return View("/Views/VistaReservas/BuscarDisponibilidadView.cshtml");

            }

            informacionClienteModel.TC_FechaInicio = reservaModel.TC_FechaInicio;
            informacionClienteModel.TC_FechaFin = reservaModel.TC_FechaFin;





            return View("/Views/VistaReservas/InformacionClienteReservaView.cshtml", informacionClienteModel);

        }

        public IActionResult CargarClienteReservacion(ReservaModel reservaModel)
        {


            return View("/Views/VistaReservas/InformacionClienteReservaView.cshtml");


        }






        [HttpPost]

        public IActionResult BuscarDatos(ReservaModel reservaModel)
        {

            ReservacionBusiness reservacionBusiness = new ReservacionBusiness(Configuration);
            InformacionClienteModel informacionClienteModel = new InformacionClienteModel();

            informacionClienteModel = reservacionBusiness.BuscarDatos(reservaModel);


            if (informacionClienteModel != null)
            {
                //return new JsonResult("putooo");

                return new JsonResult(informacionClienteModel.TC_Cedula + "," + informacionClienteModel.TC_Nombre + "," + informacionClienteModel.TC_Apellidos + "," + informacionClienteModel.TC_Email + "," + informacionClienteModel.TC_Telefono + "," + informacionClienteModel.TC_Tarjeta);
            }
            else {
                return new JsonResult("Nunca a reservado");
            }





        }


        [HttpPost]

        public IActionResult RealizarReservacion(InformacionClienteModel informacionClienteModel)
        {

            BusinessPublicidad businessPublicidad = new BusinessPublicidad(Configuration);
            List<PublicidadModel> listaPublicidad = new List<PublicidadModel>();
            listaPublicidad = businessPublicidad.cargarPublicidad();
            ViewBag.ListaPublicidad = listaPublicidad;

            BusinessOferta businessOferta = new BusinessOferta(Configuration);
            List<OfertaModel> listaOferta = new List<OfertaModel>();
            listaOferta = businessOferta.cargarOferta();
            ViewBag.ListaOferta = listaOferta;

            TipoHabitacionBusiness businessHabitacion = new TipoHabitacionBusiness(Configuration);
            List<TipoHabitacionModel> listaHabitacion = new List<TipoHabitacionModel>();
            listaHabitacion = businessHabitacion.ObtenerTipoHabitacion();
            ViewBag.ListaTipoHabitacion = listaHabitacion;



            //return new JsonResult(informacionClienteModel.TC_FechaInicio + "|" + informacionClienteModel.TC_FechaFin);
            ReservacionBusiness reservacionBusiness = new ReservacionBusiness(Configuration);
            InformacionClienteModel informacionClienteModel2 = new InformacionClienteModel();
            informacionClienteModel2 = reservacionBusiness.RealizarReservacion(informacionClienteModel);



            if (informacionClienteModel2.TN_Valido == 1) {


                enviarCorreo(informacionClienteModel2);
                return View("/Views/VistaReservas/ReservaRealizadaView.cshtml", informacionClienteModel2);
            }
            else {
                return View("/Views/VistaReservas/BuscarDisponibilidadView.cshtml");
            }

        }


        public void enviarCorreo(InformacionClienteModel informacionClienteModel)
        {

            //try
            //{
            //    SmtpMail objetoCorreo = new SmtpMail("TryIt");

            //    objetoCorreo.From = "legendaryhoteljj@gmail.com";
            //    objetoCorreo.To = informacionClienteModel.TC_Email;
            //    objetoCorreo.Subject = "Reservación Legendary Hotel Elegance & Comfort";
            //    objetoCorreo.TextBody = "Bienvenido" + informacionClienteModel.TC_Nombre_Cliente + "!" + ".\n Su reservación en Legendary Hotel Elegance & Comfort fue realizada exitosamente" + ".\n Número de reservación: " + informacionClienteModel.TC_Lista_Transaccion + ".\n Gracias por preferirnos!";
            //    System.Diagnostics.Debug.WriteLine("repuestaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa*************" + objetoCorreo.To);
            //    SmtpServer objetoServidor = new SmtpServer("smtp-relay.gmail.com");

            //    objetoServidor.User = "legendaryhoteljj@gmail.com";
            //    objetoServidor.Password = "legendaryhotel123";
            //    objetoServidor.Port = 587;
            //    objetoServidor.ConnectType = SmtpConnectType.ConnectSSLAuto;

            //    SmtpClient objetoCliente = new SmtpClient();
            //    objetoCliente.SendMail(objetoServidor, objetoCorreo);


            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("-------------------------------------*************");
            //}

            string from = "legendaryhoteljj@gmail.com";
            string displayName = "Legendary Hotel Elegance & Comfort";
            try
            {
                MailMessage mail = new MailMessage();


                mail.From = new MailAddress(from, displayName);
                mail.To.Add(informacionClienteModel.TC_Email);

                mail.Subject = "Reservación Legendary Hotel Elegance & Comfort";
                mail.Body = "<h3> Bienvenid@ " + informacionClienteModel.TC_Nombre_Cliente + "! </h3>" + "<br><br> <p> ✔ Su reservación en 𝐋𝐞𝐠𝐞𝐧𝐝𝐚𝐫𝐲 𝐇𝐨𝐭𝐞𝐥 𝐄𝐥𝐞𝐠𝐚𝐧𝐜𝐞 𝐚𝐧𝐝 𝐂𝐨𝐧𝐟𝐨𝐫𝐭 fue realizada exitosamente </p>" + "<br><br> <p> Número de reservación °: "
                    + informacionClienteModel.TC_Lista_Transaccion + "</p><br><br> <h3> Gracias por preferirnos!</h3>";
                
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
                client.Credentials = new NetworkCredential(from, "legendaryhotel123");
                client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false


                client.Send(mail);

                System.Diagnostics.Debug.WriteLine("¡Correo enviado exitosamente! Pronto te contactaremos.");

               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("¡Correo NO enviado exitosamente! Pronto te contactaremos.");
            }




        }


    }




}
