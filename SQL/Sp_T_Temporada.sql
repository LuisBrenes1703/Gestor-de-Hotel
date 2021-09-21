use Proyecto_Ingenieria_JLGS
-------------------------------------------
create procedure Sp_Extraer_Temporada
as begin
begin try
	begin tran Extraer_Temporada
	if exists(select*from T_Temporada)begin 		
		Select * from T_Temporada where T_Temporada.TC_Fecha_Inicio < GETDATE() and T_Temporada.TC_Fecha_Final > GETDATE();		
	end else begin 
		select 0 as valido;
	end
	commit tran Extraer_Temporada
end try
begin catch
	rollback tran Extraer_Temporada
	select 0 as valido;
end catch
end
go
--------------------------------------
create procedure Sp_Crear_Temporada 
	@TC_Temporada varchar(100),
	@TC_PorcentajeTemporada float,
	@fechaInicio date,
	@fechaFin date
as begin
begin try
	begin tran Crear_Temporada 
		if not exists(Select * from [T_Temporada] where (( [TC_Fecha_Inicio]<=  @fechaInicio AND  [TC_Fecha_Final] >= @fechaInicio AND  [TC_Fecha_Final] <= @fechaFin)
             or ( [TC_Fecha_Inicio] >=  @fechaInicio AND  [TC_Fecha_Final] <= @fechaFin)
            or ( [TC_Fecha_Inicio]>=  @fechaInicio AND  [TC_Fecha_Inicio] <= @fechaFin AND [TC_Fecha_Final] >= @fechaFin)
            or  ( [TC_Fecha_Inicio] <= @fechaInicio AND  [TC_Fecha_Final] >= @fechaFin) ))
			begin

			insert into [T_Temporada]([TC_Temporada],[TC_PorcentajeTemporada],[TC_Fecha_Inicio],[TC_Fecha_Final])
			values(@TC_Temporada,@TC_PorcentajeTemporada,@fechaInicio,@fechaFin);

			select 1 as valido;

		end	else begin

			select 0 as valido;
		end
	commit tran Crear_Temporada 
end try
begin catch
	rollback tran Crear_Temporada 
	select 0 as valido;
end catch
end 
go
---------------------------------------
create procedure Sp_Modificar_Temporada
	@TN_Id_Temporada int,
	@TC_Temporada varchar(100),
	@TC_PorcentajeTemporada float,
	@fechaInicio date,
	@fechaFin date
as begin
begin try
	begin tran Modificar_Reunion
		if not exists(Select * from [T_Temporada] where (( [TC_Fecha_Inicio]<=  @fechaInicio AND  [TC_Fecha_Final] >= @fechaInicio AND  [TC_Fecha_Final] <= @fechaFin)
             or ( [TC_Fecha_Inicio] >=  @fechaInicio AND  [TC_Fecha_Final] <= @fechaFin)
            or ( [TC_Fecha_Inicio]>=  @fechaInicio AND  [TC_Fecha_Inicio] <= @fechaFin AND [TC_Fecha_Final] >= @fechaFin)
            or  ( [TC_Fecha_Inicio] <= @fechaInicio AND  [TC_Fecha_Final] >= @fechaFin)) 
			AND  [TN_Id_Temporada] <> @TN_Id_Temporada)
			begin

			update [T_Temporada] set [TC_Temporada]=@TC_Temporada , [TC_PorcentajeTemporada]=@TC_PorcentajeTemporada ,[TC_Fecha_Inicio]= @fechaInicio , [TC_Fecha_Final]=@fechaFin where [TN_Id_Temporada]=@TN_Id_Temporada

			select 1 as valido;
		end	else begin
			select 0 as valido;
		end
	commit tran Modificar_Temporada 
end try
begin catch
	rollback tran Modificar_Temporada 
	select 0 as valido;
end catch
end 
go
----------------------------------------
create procedure Sp_Eliminar_Temporada
	@TN_Id_Temporada int
as begin
begin try
	begin tran Eliminar_Temporada
		if exists(Select * from [T_Temporada] where [TN_Id_Temporada] = @TN_Id_Temporada)
			begin

			Delete from [T_Temporada] where [TN_Id_Temporada]= @TN_Id_Temporada

			select 1 as valido;
		end	else begin
			select 0 as valido;
		end
	commit tran Eliminar_Temporada 
end try
begin catch
	rollback tran Eliminar_Temporada 
	select 0 as valido;
end catch
end 
go
-----------------------------------------
create procedure Sp_Mostrar_Temporadas
as begin
begin try
	begin tran Mostrar_Temporadas
		if exists(Select * from [T_Temporada])
			begin

			Select [TN_Id_Temporada], [TC_Temporada], [TC_PorcentajeTemporada], [TC_Fecha_Inicio], [TC_Fecha_Final], 1 as valido from [T_Temporada]

		end	else begin
			select 0 as valido, '' as TN_Id_Temporada, '' as TC_Temporada, '' as TC_PorcentajeTemporada, '' as TC_Fecha_Inicio, '' as TC_Fecha_Final;
		end
	commit tran Mostrar_Temporadas 
end try
begin catch
	rollback tran Mostrar_Temporadas 
	select 0 as valido, '' as TN_Id_Temporada, '' as TC_Temporada, '' as TC_PorcentajeTemporada, '' as TC_Fecha_Inicio, '' as TC_Fecha_Final;
end catch
end 
go