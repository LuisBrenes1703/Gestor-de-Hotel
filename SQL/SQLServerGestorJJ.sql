use Proyecto_Ingenieria_JLGS
-----------------------------------------------
create table T_Oferta(
	TN_Id_Oferta int identity(1,1) primary key,
	TN_Id_TipoHabitacion int  not null,
	TC_Oferta varchar(100),
	TC_PorcentajeOferta float not null,
	TC_URL_IMG varchar(1000) not null,
	TC_Fecha_Inicio date not null,
	TC_Fecha_Final date not null
	foreign key (TN_Id_TipoHabitacion) references T_TipoHabitacion(TN_Id_TipoHabitacion)
)
---------------------------------------------------
create table T_Temporada(
	TN_Id_Temporada int identity(1,1) primary key,
	TC_Temporada varchar(100) not null,
	TC_PorcentajeTemporada float not null,
	TC_Fecha_Inicio date not null,
	TC_Fecha_Final date not null
)
--------------------------------------------------
create table T_Publicidad(
	TN_Id_Publicidad int identity(1,1) primary key,
	TC_LinkPublicidad varchar(100) not null,
	TC_URL_IMG varchar(1000) not null
)
-------------------------------------------------
create table T_Galeria(
	TN_Id_Galeria int identity(1,1) primary key,
	TC_URL_IMG varchar(1000) not null
)
--------------------------------------------------
create table T_Cliente(
	TN_Id_Cliente int identity(1,1) primary key,
	TC_Cedula varchar(100) not null,
	TC_Nombre varchar(100) not null,
	TC_Apellidos varchar(100) not null,
	TC_Email varchar(100) not null,
	TC_Telefono varchar(100) not null,
	TC_Tarjeta varchar(16) not null
)
------------------------------------------------------
create table T_Usuario(
	TN_Id_Usuario int identity(1,1) primary key,
	TC_Usuario varchar(100) not null unique,
	TC_Contrasenna varbinary(500) not null,
	TB_Activo bit not null default 1,
	TN_Id_Puesto int not null,
	TB_Eliminado bit not null default 0,
	foreign key (TN_Id_Puesto) references T_Puesto (TN_Id_Puesto)
)
-----------------------------------------------------
CREATE TABLE T_Direccion(

    TN_Id_Direccion INT identity(1,1) primary key,
    TC_Descripcion VARCHAR(1000) NOT NULL,
    TC_LinkGoogleMaps VARCHAR(500) NOT NULL,
)
-------------------------------------------------
CREATE TABLE T_Hotel(
    TN_Id_Hotel INT identity(1,1) primary key,
    TC_Inicio VARCHAR(1000) NOT NULL,
    TC_SobreNosotros VARCHAR(1000) NOT NULL,
    TC_Telefono VARCHAR(15) NOT NULL,
    TC_CorreoElectronico VARCHAR(30) NOT NULL,
)
alter table T_Hotel add TC_URL_IMG varchar(1000) 
-------------------------------------------------------
create table T_Reserva(
    TN_Id_Reserva            int                    identity(1,1)    primary key,
    TC_Fecha                date                not null,
    TC_Transaccion            varchar(50)            not null,
    TC_Fecha_Inicio            date            not null,
    TC_Fecha_Final            date			not null,
    TN_Id_Cliente            int                    not null,
    TN_Id_TipoHabitacion    int                    not null,
    TN_Id_Habitacion        int                    not null,
	TB_Estado bit not null default 1,
    foreign key (TN_Id_TipoHabitacion) references T_TipoHabitacion (TN_Id_TipoHabitacion),
    foreign key (TN_Id_Habitacion) references T_Habitacion(TN_Id_Habitacion),
    foreign key (TN_Id_Cliente) references T_Cliente(TN_Id_Cliente)
)
------------------------------------------
create table T_Facilidad(

    TN_Id_Facilidad        int        identity(1,1)    primary key,
    TC_Nombre            varchar(50)        not null, 
    TC_Descripcion        varchar(1000)    not null,
    TC_URL_IMG            varchar(1000)    not null
)
-------------------------------------------------
create table T_Caracteristica_TipoHabitacion(
    TN_Id_Caracteristica int identity(1,1) primary key,
    TC_Caracteristica  varchar(100) not null,
	TN_Id_TipoHabitacion int not null,
	foreign key (TN_Id_TipoHabitacion) references T_TipoHabitacion (TN_Id_TipoHabitacion)
)
----------------------------------------------
create table T_TipoHabitacion(
    TN_Id_TipoHabitacion int identity(1,1) primary key,
    TC_TipoHabitacion varchar(100) not null unique,
    TC_Descripcion varchar(1000) not null,
    TC_Tarifa float not null,
    TN_Cantidad int not null,
    TC_URL_IMG varchar (1000) not null
)
----------------------------------------
create table T_Habitacion(
    TN_Id_Habitacion int identity(1,1) primary key,
    TN_Id_TipoHabitacion int not null,
    TB_Estado bit not null default 1,
    foreign key (TN_Id_TipoHabitacion) references T_TipoHabitacion (TN_Id_TipoHabitacion)
)
-----------------------------------
create table T_Tiempo_Reserva(
    TN_Id_Tiempo_Reserva int identity(1,1) primary key,
    TN_Id_Habitacion int not null,
	TC_Fecha_Hora datetime default null,
    TB_Estado bit not null default 1,
    foreign key (TN_Id_Habitacion) references T_Habitacion (TN_Id_Habitacion)
)
----------------------
create table T_Puesto(
	TN_Id_Puesto int identity(1,1) primary key,
	TC_Nombre_Puesto varchar(100) not null unique,
	TN_Id_Permiso int not null  --si es 1 puede tener todas las funciones administrativas
)