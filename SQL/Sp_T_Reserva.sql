use Proyecto_Ingenieria_JLGS
------------------------------------------------
create procedure Sp_Validar_Reserva
@TC_Fecha_Inicio date,
@TC_Fecha_Final date,
@TN_Id_TipoHabitacion int,
@TN_Cantidad int 
as begin
begin try
	begin tran Validar_Reserva
		if exists(select*from T_Habitacion where TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion and TB_Estado=1) begin
			declare @T_Temp_Habitacion table(TN_Id_Habitacion int,TN_Id_TipoHabitacion int,TB_Estado bit)
			declare @T_Temp_Reserva table(TN_Id_Habitacion int,TC_Fecha_Inicio datetime,TC_Fecha_Final datetime)
			declare @TN_Id_Habitacion int,@TC_Lista_Id_Habitacion varchar(max),@TC_Fecha_Inicio_Reserva datetime,@TC_Fecha_Final_Reserva datetime, @TN_Contador int
			declare @TC_TipoHabitacion varchar(100), @TC_Tarifa float, @TC_URL_IMG varchar (1000), @TN_CantidadSave int;
			declare @TC_PorcentajeOferta float
			set @TC_PorcentajeOferta=0;

			set @TN_CantidadSave=@TN_Cantidad;
			insert into @T_Temp_Habitacion select*from T_Habitacion where T_Habitacion.TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion and TB_Estado=1
			set @TC_Lista_Id_Habitacion='';
			while exists(select*from @T_Temp_Habitacion)begin
				set rowcount 1
				select @TN_Id_Habitacion=TN_Id_Habitacion from @T_Temp_Habitacion
				set rowcount 0
				set @TN_Contador=0;

				if exists(select*from T_Reserva where T_Reserva.TN_Id_Habitacion=@TN_Id_Habitacion) begin
					insert into @T_Temp_Reserva select TN_Id_Habitacion,TC_Fecha_Inicio,TC_Fecha_Final from T_Reserva where T_Reserva.TN_Id_Habitacion=@TN_Id_Habitacion

					while exists(select*from @T_Temp_Reserva)begin
						set rowcount 1
						select @TC_Fecha_Inicio_Reserva=TC_Fecha_Inicio,@TC_Fecha_Final_Reserva=TC_Fecha_Final  from @T_Temp_Reserva
						set rowcount 0
						if(@TC_Fecha_Inicio>=@TC_Fecha_Final_Reserva or @TC_Fecha_Final<=@TC_Fecha_Inicio_Reserva)begin
							set @TN_Contador+=1;
						end
						set rowcount 1
						delete @T_Temp_Reserva;
						set rowcount 0
					end
					if(@TN_Contador=(select count(*) from T_Reserva where T_Reserva.TN_Id_Habitacion=@TN_Id_Habitacion))begin
						set @TC_Lista_Id_Habitacion+=CAST(@TN_Id_Habitacion as varchar(max))
						set @TC_Lista_Id_Habitacion+=','
						update T_Habitacion set T_Habitacion.TB_Estado=0 where T_Habitacion.TN_Id_Habitacion=@TN_Id_Habitacion
						set @TN_Cantidad-=1;
					end
				end else begin
					set @TC_Lista_Id_Habitacion+=CAST(@TN_Id_Habitacion as varchar(max))
					set @TC_Lista_Id_Habitacion+=','
					update T_Habitacion set T_Habitacion.TB_Estado=0 where T_Habitacion.TN_Id_Habitacion=@TN_Id_Habitacion
					set @TN_Cantidad-=1;
				end
				if(@TN_Cantidad=0)begin
					break;
				end
				delete @T_Temp_Habitacion where TN_Id_Habitacion=@TN_Id_Habitacion;
			end	
			if(@TN_Cantidad=0)begin	
				select @TC_TipoHabitacion=TC_TipoHabitacion from T_TipoHabitacion where TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion
				select @TC_Tarifa=TC_Tarifa from T_TipoHabitacion where TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion
				select @TC_URL_IMG=TC_URL_IMG from T_TipoHabitacion where TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion
				set @TC_Tarifa=@TC_Tarifa*@TN_CantidadSave

				Declare @T_Tiempo TABLE(TN_Id_Habitacion int);
				insert into @T_Tiempo select value from string_split(SUBSTRING (@TC_Lista_Id_Habitacion, 1, Len(@TC_Lista_Id_Habitacion) - 1 ),',');
				while exists(select*from @T_Tiempo)begin
					set rowcount 1
					select @TN_Id_Habitacion=TN_Id_Habitacion from @T_Tiempo
					set rowcount 0
					insert into T_Tiempo_Reserva(TN_Id_Habitacion,TC_Fecha_Hora) values (@TN_Id_Habitacion,getdate());
					delete @T_Tiempo where TN_Id_Habitacion=@TN_Id_Habitacion;
				end
				
				if exists(select*from T_Oferta where T_Oferta.TC_Fecha_Inicio<= GETDATE() and T_Oferta.TC_Fecha_Final>= GETDATE() and T_Oferta.TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion)begin
					select @TC_PorcentajeOferta=TC_PorcentajeOferta from T_Oferta where T_Oferta.TC_Fecha_Inicio<= GETDATE() and T_Oferta.TC_Fecha_Final>= GETDATE() and T_Oferta.TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion
				end
				select 1 as TN_Valido,@TC_TipoHabitacion as TC_TipoHabitacion,SUBSTRING (@TC_Lista_Id_Habitacion, 1, Len(@TC_Lista_Id_Habitacion) - 1 ) as TC_IdsHabitaciones,@TC_Tarifa as TC_Tarifa,@TC_URL_IMG as TC_URL_IMG, @TC_PorcentajeOferta as TC_PorcentajeOferta
			end else begin
				Declare @T_Restablecer TABLE(TN_Id_Habitacion int);
				insert into @T_Restablecer select value from string_split(SUBSTRING (@TC_Lista_Id_Habitacion, 1, Len(@TC_Lista_Id_Habitacion) - 1 ),',');
				while exists(select*from @T_Restablecer)begin
					set rowcount 1
					select @TN_Id_Habitacion=TN_Id_Habitacion from @T_Restablecer
					set rowcount 0
					update T_Habitacion set T_Habitacion.TB_Estado=1 where T_Habitacion.TN_Id_Habitacion=@TN_Id_Habitacion
					delete @T_Restablecer where TN_Id_Habitacion=@TN_Id_Habitacion;
				end

				select 0 as TN_Valido,@TC_TipoHabitacion as TC_TipoHabitacion,@TC_Tarifa as TC_Tarifa,@TC_URL_IMG as TC_URL_IMG;
			end		
		end else begin
			select 0 as TN_Valido,@TC_TipoHabitacion as TC_TipoHabitacion,@TC_Lista_Id_Habitacion as TC_IdsHabitaciones,@TC_Tarifa as TC_Tarifa,@TC_URL_IMG as TC_URL_IMG,@TC_PorcentajeOferta as TC_PorcentajeOferta
		end
	commit tran Listar_Publicidad
end try
begin catch
	rollback tran Validar_Reserva
	select 0 as TN_Valido,@TC_TipoHabitacion as TC_TipoHabitacion,@TC_Lista_Id_Habitacion as TC_IdsHabitaciones,@TC_Tarifa as TC_Tarifa,@TC_URL_IMG as TC_URL_IMG,@TC_PorcentajeOferta as TC_PorcentajeOferta
end catch
end
go
------------------------------------------------------
create procedure Sp_Realizar_Reserva
@TC_Lista_Id_Habitacion varchar(100),
@TC_Cedula varchar(100),
@TC_Nombre varchar(100),
@TC_Apellidos varchar(100),
@TC_Email varchar(100),
@TC_Telefono varchar(100),
@TC_Tarjeta varchar(16),
@TC_Fecha_Inicio date,
@TC_Fecha_Final date,
@TC_GUID_Reservacion varchar(50)
as begin
begin try
	begin tran Realizar_Reserva
		Declare @TN_Id_Habitacion int, @TN_Id_Cliente int, @TN_Id_TipoHabitacion int, @ClienteNuevo int, @TC_Nombre_Cliente varchar(max)
		set @ClienteNuevo=0;
		set @TC_Nombre_Cliente=''
		if not exists(select*from T_Cliente where T_Cliente.TC_Cedula=@TC_Cedula)begin
			execute Sp_Insert_Cliente @TC_Cedula,@TC_Nombre,@TC_Apellidos,@TC_Email,@TC_Telefono,@TC_Tarjeta
			set @ClienteNuevo=1;
		end else begin
            Declare @TC_NombreR varchar(100), @TC_ApellidosR varchar(100), @TC_EmailR varchar(100), @TC_TelefonoR varchar(100),@TC_TarjetaR varchar(16)
            select  @TC_NombreR=T_Cliente.TC_Nombre,@TC_ApellidosR=T_Cliente.TC_Apellidos,@TC_EmailR= T_Cliente.TC_Email,@TC_TelefonoR=T_Cliente.TC_Telefono,@TC_TarjetaR= T_Cliente.TC_Tarjeta from T_Cliente where T_Cliente.TC_Cedula=@TC_Cedula
            if(@TC_NombreR!=@TC_Nombre)begin
				update T_Cliente set TC_Nombre=@TC_Nombre where T_Cliente.TC_Cedula=@TC_Cedula 
            end
			if(@TC_ApellidosR!=@TC_Apellidos)begin
				update T_Cliente set TC_Apellidos =@TC_Apellidos where T_Cliente.TC_Cedula=@TC_Cedula 
            end
			if(@TC_EmailR!=@TC_Email)begin
				update T_Cliente set TC_Email =@TC_Email where T_Cliente.TC_Cedula=@TC_Cedula 
            end
			if(@TC_TelefonoR!=@TC_Telefono)begin
				update T_Cliente set TC_Telefono =@TC_Telefono where T_Cliente.TC_Cedula=@TC_Cedula 
            end
			if(@TC_TarjetaR!=@TC_Tarjeta)begin
				update T_Cliente set TC_Tarjeta =@TC_Tarjeta where T_Cliente.TC_Cedula=@TC_Cedula 
            end
        end
		Declare @T_TN_Id_Habitacion TABLE(TN_Id_Habitacion int);
		insert into @T_TN_Id_Habitacion select value from string_split(@TC_Lista_Id_Habitacion,',');
		declare @tiempo int
		set @tiempo=1;
		while exists(select*from @T_TN_Id_Habitacion)begin
			set rowcount 1
			select @TN_Id_Habitacion=TN_Id_Habitacion from @T_TN_Id_Habitacion
			set rowcount 0

			if exists(select * from T_Tiempo_Reserva where DATEDIFF(minute,TC_Fecha_Hora,getdate()) >=5 and TB_Estado=1 and TN_Id_Habitacion=@TN_Id_Habitacion)begin
				set @tiempo=0;
				delete @T_TN_Id_Habitacion
			end else begin 
				select  @TN_Id_Cliente=TN_Id_Cliente from T_Cliente where T_Cliente.TC_Cedula=@TC_Cedula
				select  @TN_Id_TipoHabitacion=TN_Id_TipoHabitacion from T_Habitacion where T_Habitacion.TN_Id_Habitacion=@TN_Id_Habitacion
	
				insert into T_Reserva (TC_Fecha,TC_Transaccion,TC_Fecha_Inicio,TC_Fecha_Final,TN_Id_Cliente,TN_Id_TipoHabitacion,TN_Id_Habitacion) values(getdate(),@TC_GUID_Reservacion,@TC_Fecha_Inicio,@TC_Fecha_Final,@TN_Id_Cliente,@TN_Id_TipoHabitacion,@TN_Id_Habitacion)
				update T_Habitacion set TB_Estado=1 where TN_Id_Habitacion=@TN_Id_Habitacion
				delete @T_TN_Id_Habitacion where TN_Id_Habitacion=@TN_Id_Habitacion
			end
			
		end
		set @TC_Nombre_Cliente+=@TC_Nombre
		set @TC_Nombre_Cliente+=' '
		set @TC_Nombre_Cliente+=@TC_Apellidos

		if (@tiempo=1)begin
			select 1 as TN_Valido, @ClienteNuevo as TN_ClienteNuevo,@TC_Nombre_Cliente as TC_Nombre_Cliente, @TC_GUID_Reservacion as TC_Lista_Transaccion, @TC_Email as TC_Email
		end else begin
			select 0 as TN_Valido, '' as TN_ClienteNuevo,'' as TC_Nombre_Cliente, '' as TC_Lista_Transaccion, '' as TC_Email
		end
		
	commit tran Realizar_Reserva
	end try
begin catch
	rollback tran Realizar_Reserva
	select 0 as TN_Valido, 0 as  TN_ClienteNuevo,'' as TC_Nombre_Cliente, '' as TC_Lista_Transaccion, '' as TC_Email
end catch
end
go
--------------------------------------------
create procedure Sp_Validar_Tiempos
as begin
begin try
	begin tran Validar_Tiempos
		if exists(select*from T_Tiempo_Reserva)begin
		declare @contador int, @TN_Id_Habitacion int
		set @contador=0;
		select @contador=COUNT(*) from T_Tiempo_Reserva
			while (@contador>0) begin
				if exists(select * from T_Tiempo_Reserva where DATEDIFF(minute,TC_Fecha_Hora,getdate()) >=5 and TB_Estado=1) begin
					set rowcount 1
					select @TN_Id_Habitacion=TN_Id_Habitacion from T_Tiempo_Reserva where DATEDIFF(minute,TC_Fecha_Hora,getdate()) >=5 and TB_Estado=1
					set rowcount 0
					update T_Habitacion set TB_Estado=1 where TN_Id_Habitacion=@TN_Id_Habitacion
					delete T_Tiempo_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion
				end
				set @contador-=1	
			end
		end
	commit tran Validar_Tiempos
	end try
begin catch
	rollback tran Validar_Tiempos
	select 0 as TN_Valido
end catch
end
go
---------------------------------------------------------
create procedure Sp_Delete_Reserva 
	@TN_Id_Reserva int
as begin
begin try
	begin tran Delete_Reserva 

		if exists(select*from T_Reserva where TN_Id_Reserva=@TN_Id_Reserva)begin
			DELETE FROM T_Reserva where T_Reserva.TN_Id_Reserva=@TN_Id_Reserva;

			select 1 as valido;
		end else begin
			select 0 as valido;
		end
	commit tran Delete_Reserva
end try
begin catch
	rollback tran Delete_Reserva
	select 0 as valido;
end catch
end 
go
-------------------------------------------------------
create procedure Sp_Listar_Reserva
as begin
begin try
	begin tran Listar_Reserva

		select	1 as valido, T_Reserva.TC_Fecha, T_Reserva.TN_Id_Reserva,
		T_Cliente.TC_Nombre,T_Cliente.TC_Apellidos,T_Cliente.TC_Email,
		T_Cliente.TC_Tarjeta,T_Reserva.TC_Transaccion,T_Reserva.TC_Fecha_Inicio,
		T_Reserva.TC_Fecha_Final,T_TipoHabitacion.TC_TipoHabitacion 
		from T_Reserva
		inner JOIN T_Cliente on T_Reserva.TN_Id_Cliente=T_Cliente.TN_Id_Cliente
		inner JOIN T_TipoHabitacion on T_Reserva.TN_Id_TipoHabitacion=T_TipoHabitacion.TN_Id_TipoHabitacion;

	commit tran Listar_Reserva
end try
begin catch
	rollback tran Listar_Reserva
    select	0 as valido,'' as TC_Fecha, '' as TN_Id_Reserva, '' as TC_Nombre, '' as TC_Apellidos,
	'' as TC_Email, '' as TC_Tarjeta, '' as TC_Transaccion, '' as TC_Fecha_Inicio, '' as TC_Fecha_Final,
	'' as TC_TipoHabitacion
end catch
end
go
----------------------------------------------
create procedure Sp_get_Reserva
@TN_Id_Reserva int
as begin
begin try
	begin tran Listar_Reserva

		select	1 as valido, T_Reserva.TC_Fecha, T_Reserva.TN_Id_Reserva,
		T_Cliente.TC_Nombre,T_Cliente.TC_Apellidos,T_Cliente.TC_Email,
		T_Cliente.TC_Tarjeta,T_Reserva.TC_Transaccion,T_Reserva.TC_Fecha_Inicio,
		T_Reserva.TC_Fecha_Final,T_TipoHabitacion.TC_TipoHabitacion 
		from T_Reserva 
		inner JOIN T_Cliente on T_Reserva.TN_Id_Cliente=T_Cliente.TN_Id_Cliente
		inner JOIN T_TipoHabitacion on T_Reserva.TN_Id_TipoHabitacion=T_TipoHabitacion.TN_Id_TipoHabitacion
		where T_Reserva.TN_Id_Reserva=@TN_Id_Reserva;

	commit tran Listar_Reserva
end try
begin catch
	rollback tran Listar_Reserva
    select	0 as valido,'' as TC_Fecha, '' as TN_Id_Reserva, '' as TC_Nombre, '' as TC_Apellidos,
	'' as TC_Email, '' as TC_Tarjeta, '' as TC_Transaccion, '' as TC_Fecha_Inicio, '' as TC_Fecha_Final,
	'' as TC_TipoHabitacion
end catch
end
go
----------------------------------------------------
