use Proyecto_Ingenieria_JLGS
/***********Se debe especificar el nombre del puesto y el id se debe dejar en 1***************/
Insert T_Puesto(TC_Nombre_Puesto,TN_Id_Permiso) values ('Administrador', '1');
/***********Se debe especificar el usuario, contraseña la cual sera encriptada, el estado debe ser 1 para que dicho usuario se encuentre activo, id del puesto, y 0 en eliminado para identificar que esta vigente***************/
Insert T_Usuario(TC_Usuario,TC_Contrasenna, TB_Activo, TN_Id_Puesto, TB_Eliminado) values ('Admin', dbo.ENCRIPTA_PASS('123'), 1, 1, 0);
/***********Se debe crear un hotel base para que exista en el sistema***************/
Insert T_Hotel(TC_Inicio,TC_SobreNosotros,TC_Telefono,TC_CorreoElectronico) values('Texto inicio','Texto sobre nosotros','+000 0000-0000','/assets/img/hotel/imagen.jpg');