


function buscarDatos() {

    var cedula = $("#TC_Cedula").val();

    if (cedula.length == 9) {       

        var parametros = {"TC_Cedula": cedula};

        $.ajax(
            {
                data: parametros,
                url: '/Reservacion/BuscarDatos',
                type: 'post',
                beforeSend: function () {
                    $("#tareaDatos").html("Procesando, espere por favor ...");
                },
                success: function (response) {                          

                    //alert(response);
                    if (response == "Nunca a reservado") {
                        //alert("Nunca a reservado");
                    } else {
                        
                        var vector = response.split(",");               
                        var informacionClienteModel = new Object();
                        informacionClienteModel.TC_Cedula = vector[0];
                        informacionClienteModel.TC_Nombre = vector[1];
                        informacionClienteModel.TC_Apellidos = vector[2];
                        informacionClienteModel.TC_Email = vector[3];
                        informacionClienteModel.TC_Telefono = vector[4];
                        informacionClienteModel.TC_Tarjeta = vector[5];

                        $("#TC_Cedula").val(informacionClienteModel.TC_Cedula);
                        $("#TC_Nombre").val(informacionClienteModel.TC_Nombre);
                        $("#TC_Apellidos").val(informacionClienteModel.TC_Apellidos);
                        $("#TC_Email").val(informacionClienteModel.TC_Email);
                        $("#TC_Telefono").val(informacionClienteModel.TC_Telefono);
                        $("#TC_Tarjeta").val(informacionClienteModel.TC_Tarjeta);
                        

                        
                    }

                }
            }
        );

    }

}




function preReserva() {

    var proce = document.getElementsByName('radio');

    for (i = 0; i < proce.length; i++) {
        if (proce[i].checked) {
            var processor = proce[i].id;
        }

    }



    $("#TN_Id_TipoHabitacion").val(processor);

    //cantidadHabitaciones, fechaInicio, fechaFin

    //var parametros = {
    //    "TN_Cantidad": cantidadHabitaciones,
    //    "TC_FechaInicio": fechaInicio,
    //    "TC_FechaFin": fechaFin,
    //    "TN_Id_TipoHabitacion": processor
    //};

    //    $.ajax(
    //        {
    //            data: parametros,
    //            url: '/Reservacion/InformacionClienteReservaView',
    //            type: 'post',
    //            beforeSend: function () {
    //                $("#resultado").html("Procesando, espere por favor ...");
    //            },
    //            success: function (response) {
    //                redireccion('/Reservacion/CargarClienteReservacion');
                   

    //                //list = response.split('|');


    //            }
    //        }
    //    );

}



function cargarBuscarDisponibilidadView() {
    redireccion('/Reservacion/BuscarDisponibilidadView');
}

function redireccion(direccion) {
    document.location.href = direccion;
}


function ModificarTemporada(TN_Id_Temporada, TC_Temporada, TC_PorcentajeTemporada, TC_Fecha_Inicio, TC_Fecha_Final) {
    var parametros = { "TN_Id_Temporada": TN_Id_Temporada, "TC_Temporada": TC_Temporada, "TC_PorcentajeTemporada": TC_PorcentajeTemporada, "TC_Fecha_Inicio": TC_Fecha_Inicio, "TC_Fecha_Final": TC_Fecha_Final };
   
    $.ajax(
        {
            data: parametros,
            url: '/Temporada/ModificarTemporada',
            type: 'post',
            beforeSend: function () {
                $("#ResultadoTM" + TN_Id_Temporada).html("Espere por favor ...");
            },
            success: function (response) {
                if (response == "1") {
                    $("#ResultadoTM"+TN_Id_Temporada).html("Modificado!");
                } else {
                    $("#ResultadoTM" +TN_Id_Temporada).html("Error en modificar");
                }

            }
        }
    );
} // 


function eliminarTemporada(TN_Id_Temporada) {
    var parametros = { "TN_Id_Temporada": TN_Id_Temporada };
    $.ajax(
        {
            data: parametros,
            url: '/Temporada/EliminarTemporada',
            type: 'post',
            beforeSend: function () {
                $("#ResultadoTE"+TN_Id_Temporada).html("Espere por favor ...");
            },
            success: function (response) {
                if (response == "1") {
                    $("#fila"+TN_Id_Temporada).remove();
                } else {
                    $("#ResultadoTE"+TN_Id_Temporada).html("Error en eliminar");
                }

            }
        }
    );
} // 

function CancelarTipoHabitacion() {
    redireccion('/TipoHabitacion/VerCRUDTipoHabitacion');
  
} // 


function CancelarFacilidades() {
    redireccion('/HotelAdministrador/VerModificarFacilidades');
} // 



function EliminarFacilidad(TN_Id_Facilidad) {

    var id = document.getElementById(TN_Id_Facilidad).value;
    var parametros = { "TN_Id_Facilidad": id };
    $.ajax(
        {
            data: parametros,
            url: '/Facilidad/EliminarFacilidad',
            type: 'post',
            success: function (response) {
                if (response == "1") {

                    redireccion('/HotelAdministrador/VerModificarFacilidades');
                } 
               

            }
        }
    );

} //

function CancelarModificarHome() {

    redireccion('/Usuario/IndexAdministrador');
}



