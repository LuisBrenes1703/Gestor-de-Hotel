use Proyecto_Ingenieria_JLGS
---------------------------------------------------
create procedure Sp_Ver_Estado_Habitaciones
as begin
begin try
	begin tran Ver_Estado_Habitaciones
		if exists(select*from T_Habitacion)begin

			Declare @T_Temp_Habitacion TABLE(TN_Id_Habitacion int, TC_TipoHabitacion varchar(100), TB_Estado bit);
			Declare @T_Ver_Estado_Habitacion TABLE(TN_Id_Habitacion int, TC_TipoHabitacion varchar(100),TC_Estado varchar(100),TB_Bit bit);
			Declare @TN_Id_Habitacion int, @TC_TipoHabitacion varchar(100), @TB_Estado bit, @TB_Estado_Tiempo bit

			insert into @T_Temp_Habitacion select TN_Id_Habitacion,T_TipoHabitacion.TC_TipoHabitacion,TB_Estado from T_Habitacion 
			inner join T_TipoHabitacion on T_Habitacion.TN_Id_TipoHabitacion=T_TipoHabitacion.TN_Id_TipoHabitacion

			while exists(select*from @T_Temp_Habitacion)begin

				set rowcount 1
				select @TN_Id_Habitacion=TN_Id_Habitacion,@TC_TipoHabitacion=TC_TipoHabitacion,@TB_Estado=TB_Estado   from @T_Temp_Habitacion
				set rowcount 0

				if exists(select*from T_Tiempo_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion)begin
					select @TB_Estado_Tiempo=TB_Estado from T_Tiempo_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion;
				end else begin
					set @TB_Estado_Tiempo=-1
				end
				if (@TB_Estado=0 and @TB_Estado_Tiempo=0)begin
					insert into @T_Ver_Estado_Habitacion (TN_Id_Habitacion, TC_TipoHabitacion,TC_Estado,TB_Bit) values (@TN_Id_Habitacion,@TC_TipoHabitacion, 'DESHABILITADA',0)
				end else if exists(Select*from T_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion and T_Reserva.TC_Fecha_Inicio<=GETDATE() and T_Reserva.TC_Fecha_Final>= GETDATE())begin
					insert into @T_Ver_Estado_Habitacion (TN_Id_Habitacion, TC_TipoHabitacion,TC_Estado,TB_Bit) values (@TN_Id_Habitacion,@TC_TipoHabitacion, 'RESERVADA',1)
				end else if (@TB_Estado=0)begin
					insert into @T_Ver_Estado_Habitacion (TN_Id_Habitacion, TC_TipoHabitacion,TC_Estado,TB_Bit) values (@TN_Id_Habitacion,@TC_TipoHabitacion, 'OCUPADA',1)
				end else begin
					insert into @T_Ver_Estado_Habitacion (TN_Id_Habitacion, TC_TipoHabitacion,TC_Estado,TB_Bit) values (@TN_Id_Habitacion,@TC_TipoHabitacion, 'DISPONIBLE',1)
				end

				delete @T_Temp_Habitacion where TN_Id_Habitacion=@TN_Id_Habitacion

			end
						select 1 as valido,TN_Id_Habitacion,TC_TipoHabitacion,TC_Estado,TB_Bit  from @T_Ver_Estado_Habitacion
		end else begin
			select 0 as valido,0 as TN_Id_Habitacion,'' as TC_TipoHabitacion,'' as TC_Estado,'' as TB_Bit  from @T_Ver_Estado_Habitacion
		end

	commit tran Ver_Estado_Habitaciones
	end try
begin catch
	rollback tran Ver_Estado_Habitaciones
end catch
end
go
---------------------------------------------------
create procedure Sp_Consultar_Disponibilidad
@TC_Fecha_Inicio date,
@TC_Fecha_Final date,
@TN_Id_TipoHabitacion int
as begin
begin try
	begin tran Consultar_Disponibilidad
		if exists(select*from T_Habitacion)begin

			Declare @T_Temp_Habitacion TABLE(TN_Id_Habitacion int, TC_TipoHabitacion varchar(100), TB_Estado bit);
			Declare @T_Ver_Estado_Habitacion TABLE(TN_Id_Habitacion int, TC_TipoHabitacion varchar(100),TC_Estado varchar(100));
			Declare @TN_Id_Habitacion int, @TC_TipoHabitacion varchar(100), @TB_Estado bit, @TB_Estado_Tiempo bit

			insert into @T_Temp_Habitacion select TN_Id_Habitacion,T_TipoHabitacion.TC_TipoHabitacion,TB_Estado from T_Habitacion 
			inner join T_TipoHabitacion on T_Habitacion.TN_Id_TipoHabitacion=T_TipoHabitacion.TN_Id_TipoHabitacion where T_Habitacion.TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion

			while exists(select*from @T_Temp_Habitacion)begin

				set rowcount 1
				select @TN_Id_Habitacion=TN_Id_Habitacion,@TC_TipoHabitacion=TC_TipoHabitacion,@TB_Estado=TB_Estado   from @T_Temp_Habitacion
				set rowcount 0

				if exists(select*from T_Tiempo_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion)begin
					select @TB_Estado_Tiempo=TB_Estado from T_Tiempo_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion;
				end else begin
					set @TB_Estado_Tiempo=-1
				end

				if (@TB_Estado=0 and @TB_Estado_Tiempo=0)begin
					insert into @T_Ver_Estado_Habitacion (TN_Id_Habitacion, TC_TipoHabitacion,TC_Estado) values (@TN_Id_Habitacion,@TC_TipoHabitacion, 'DESHABILITADA')
				end else if exists(Select*from T_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion and ((T_Reserva.TC_Fecha_Inicio<=@TC_Fecha_Final and  TC_Fecha_Inicio>= @TC_Fecha_Inicio) or (T_Reserva.TC_Fecha_Final>= @TC_Fecha_Inicio and TC_Fecha_Final<=@TC_Fecha_Final)))begin
					insert into @T_Ver_Estado_Habitacion (TN_Id_Habitacion, TC_TipoHabitacion,TC_Estado) values (@TN_Id_Habitacion,@TC_TipoHabitacion, 'RESERVADA')
				end else if (@TB_Estado=0)begin
					insert into @T_Ver_Estado_Habitacion (TN_Id_Habitacion, TC_TipoHabitacion,TC_Estado) values (@TN_Id_Habitacion,@TC_TipoHabitacion, 'OCUPADA')
				end else begin
					insert into @T_Ver_Estado_Habitacion (TN_Id_Habitacion, TC_TipoHabitacion,TC_Estado) values (@TN_Id_Habitacion,@TC_TipoHabitacion, 'DISPONIBLE')
				end

				delete @T_Temp_Habitacion where TN_Id_Habitacion=@TN_Id_Habitacion
			end
				select 1 as valido,TN_Id_Habitacion,TC_TipoHabitacion,TC_Estado  from @T_Ver_Estado_Habitacion
		end else begin
			select 0 as valido,0 as TN_Id_Habitacion,'' as TC_TipoHabitacion,'' as TC_Estado  from @T_Ver_Estado_Habitacion
		end

	commit tran Consultar_Disponibilidad
	end try
begin catch
	rollback tran Consultar_Disponibilidad
end catch
end
go
---------------------------------------------------
create procedure Sp_Deshabilitar_Habitacion
@TN_Id_Habitacion int
as begin
begin try
	begin tran Deshabilitar_Habitacion

	declare @TB_Estado_Habitacion bit, @TB_Estado_Tiempo_Reserva bit
	if exists(select*from T_Habitacion where TN_Id_Habitacion=@TN_Id_Habitacion)begin
		select @TB_Estado_Habitacion=TB_Estado from T_Habitacion where TN_Id_Habitacion=@TN_Id_Habitacion
		if exists(select*from T_Tiempo_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion)begin
			select @TB_Estado_Tiempo_Reserva=TB_Estado from T_Tiempo_Reserva where TN_Id_Habitacion=@TN_Id_Habitacion
			if (@TB_Estado_Tiempo_Reserva=1)begin
				update T_Habitacion set TB_Estado=0 where TN_Id_Habitacion=@TN_Id_Habitacion
				update T_Tiempo_Reserva set TB_Estado=0 where TN_Id_Habitacion=@TN_Id_Habitacion	
			end else begin
				update T_Tiempo_Reserva set TB_Estado=1 where TN_Id_Habitacion=@TN_Id_Habitacion
			end	
		end else begin
			update T_Habitacion set TB_Estado=0 where TN_Id_Habitacion=@TN_Id_Habitacion
			insert into T_Tiempo_Reserva(TN_Id_Habitacion,TC_Fecha_Hora,TB_Estado) values (@TN_Id_Habitacion,getdate(),0);
		end
	end
	commit tran Deshabilitar_Habitacion
	end try
begin catch
	rollback tran Deshabilitar_Habitacion
end catch
end
go
---------------------------------------------------