use Proyecto_Ingenieria_JLGS
----------------------------------------------
create procedure Sp_Extraer_TipoHabitacion
as begin
begin try
    begin tran Extraer_TipoHabitacion
    if exists(select*from T_TipoHabitacion)begin
		Declare @T_TipoHabitacionFinal TABLE(TN_Id_TipoHabitacion int,TC_TipoHabitacion varchar(100),TC_Descripcion varchar(1000),TC_Tarifa float,TN_Cantidad int,TC_URL_IMG varchar(1000),TC_PorcentajeOferta float);
		Declare @T_TipoHabitacionTemp TABLE(TN_Id_TipoHabitacion int,TC_TipoHabitacion varchar(100),TC_Descripcion varchar(1000),TC_Tarifa float,TN_Cantidad int,TC_URL_IMG varchar(1000));
		insert into @T_TipoHabitacionTemp  Select T_TipoHabitacion.TN_Id_TipoHabitacion,T_TipoHabitacion.TC_TipoHabitacion,T_TipoHabitacion.TC_Descripcion,T_TipoHabitacion.TC_Tarifa,TN_Cantidad,T_TipoHabitacion.TC_URL_IMG from T_TipoHabitacion 
		declare @TN_Id_TipoHabitacion int,@TC_TipoHabitacion varchar(100),@TC_Descripcion varchar(1000),@TC_Tarifa float,@TN_Cantidad int,@TC_URL_IMG varchar(1000),@TC_PorcentajeOferta float
		while exists(select*from @T_TipoHabitacionTemp)begin
			set rowcount 1
			select @TN_Id_TipoHabitacion=TN_Id_TipoHabitacion,@TC_TipoHabitacion=TC_TipoHabitacion,@TC_Descripcion=TC_Descripcion,@TC_Tarifa=TC_Tarifa,@TN_Cantidad=TN_Cantidad,@TC_URL_IMG=TC_URL_IMG from @T_TipoHabitacionTemp
			set rowcount 0
			if exists(select*from T_Oferta where T_Oferta.TC_Fecha_Inicio<= GETDATE() and T_Oferta.TC_Fecha_Final>= GETDATE() and T_Oferta.TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion)begin
				select @TC_PorcentajeOferta=TC_PorcentajeOferta from T_Oferta where T_Oferta.TC_Fecha_Inicio<= GETDATE() and T_Oferta.TC_Fecha_Final>= GETDATE() and T_Oferta.TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion
				insert into @T_TipoHabitacionFinal(TN_Id_TipoHabitacion ,TC_TipoHabitacion ,TC_Descripcion ,TC_Tarifa ,TN_Cantidad ,TC_URL_IMG ,TC_PorcentajeOferta) values(@TN_Id_TipoHabitacion ,@TC_TipoHabitacion ,@TC_Descripcion ,@TC_Tarifa ,@TN_Cantidad ,@TC_URL_IMG,@TC_PorcentajeOferta)
			end else begin
				insert into @T_TipoHabitacionFinal(TN_Id_TipoHabitacion ,TC_TipoHabitacion ,TC_Descripcion ,TC_Tarifa ,TN_Cantidad ,TC_URL_IMG ,TC_PorcentajeOferta) values(@TN_Id_TipoHabitacion ,@TC_TipoHabitacion ,@TC_Descripcion ,@TC_Tarifa ,@TN_Cantidad ,@TC_URL_IMG,0)
			end
	
			delete @T_TipoHabitacionTemp where TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion

		end
		select*from @T_TipoHabitacionFinal

    end else begin 
        select 0 as valido;
    end
    commit tran Extraer_TipoHabitacion
end try
begin catch
    rollback tran Extraer_TipoHabitacion
    select 0 as valido;
end catch
end
go
-----------------------------------------------------
create procedure Sp_Crear_Tipo_Habitacion
	@TC_TipoHabitacion varchar(100),
	@TC_Descripcion varchar(1000),
	@TC_Tarifa float,
	@TN_Cantidad int,
	@TC_URL_IMG varchar(1000)
as begin
begin try
	begin tran Crear_Tipo_Habitacion

		if not exists(Select * from [dbo].[T_TipoHabitacion] where ([TC_TipoHabitacion] =  @TC_TipoHabitacion ))
			begin
			declare @TN_Id_TipoHabitacion int, @cont int;
			set @cont = 1;

			insert into[T_TipoHabitacion]([TC_TipoHabitacion], [TC_Descripcion],[TC_Tarifa], [TN_Cantidad],[TC_URL_IMG])
			values(@TC_TipoHabitacion, @TC_Descripcion,@TC_Tarifa,@TN_Cantidad,@TC_URL_IMG);

			select @TN_Id_TipoHabitacion= TN_Id_TipoHabitacion from [T_TipoHabitacion] where [TC_TipoHabitacion] =  @TC_TipoHabitacion;  
			
			while (@cont <= @TN_Cantidad)begin
                    set rowcount 1
                   insert into[T_Habitacion]([TN_Id_TipoHabitacion], [TB_Estado])
						values(@TN_Id_TipoHabitacion, 1);

						 set @cont = @cont+1     
                    set rowcount 0

            end

			select 1 as valido;
		end	else begin

			select 0 as valido;
		end
	commit tran Crear_Tipo_Habitacion 
end try
begin catch
	rollback tran Crear_Tipo_Habitacion 
	select 0 as valido;
end catch
end 
go
------------------------------------------------------
create procedure Sp_Modificar_Tipo_Habitacion
	@TN_Id_TipoHabitacion int,
	@TC_Descripcion varchar(1000),
	@TC_Tarifa float,
	@TC_URL_IMG varchar(1000)
as begin
begin try
	begin tran Modificar_Tipo_Habitacion
		if exists(Select * from [dbo].[T_TipoHabitacion] where ( [TN_Id_TipoHabitacion]<=  @TN_Id_TipoHabitacion ))
			begin

			update [T_TipoHabitacion] set [TC_Descripcion]= @TC_Descripcion , [TC_Tarifa]= @TC_Tarifa ,[TC_URL_IMG]= @TC_URL_IMG where [TN_Id_TipoHabitacion] = @TN_Id_TipoHabitacion
			 
			select 1 as valido;
		end	else begin
			select 0 as valido;
		end
	commit tran Modificar_Tipo_Habitacion 
end try
begin catch
	rollback tran Modificar_Tipo_Habitacion 
	select 0 as valido;
end catch
end 
go
