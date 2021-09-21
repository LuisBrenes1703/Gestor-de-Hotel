use Proyecto_Ingenieria_JLGS
---------------------------------------
create procedure Sp_Modificar_Facilidades
	@TN_Id_Facilidad int,
	@TC_Descripcion_Facilidad varchar(1000),
	@TC_URL_IMG varchar(1000)
as begin
begin try
	begin tran Modificar_Facilidades
		if exists(Select * from [dbo].[T_Facilidad] where ( [TN_Id_Facilidad]<=  @TN_Id_Facilidad ))
			begin

			update [T_Facilidad] set [TC_Descripcion]= @TC_Descripcion_Facilidad ,[TC_URL_IMG]= @TC_URL_IMG where [TN_Id_Facilidad] = @TN_Id_Facilidad
			 
			select 1 as valido;
		end	else begin
			select 0 as valido;
		end
	commit tran Modificar_Facilidades 
end try
begin catch
	rollback tran Modificar_Facilidades 
	select 0 as valido;
end catch
end 
-----------------------------------------------------------------
create procedure Sp_Eliminar_Facilidad
	@TN_Id_Facilidad int
as begin
begin try
	begin tran Eliminar_Facilidades
		if exists(Select * from [T_Facilidad] where [TN_Id_Facilidad] = @TN_Id_Facilidad)
			begin

			Delete from [T_Facilidad] where [TN_Id_Facilidad] = @TN_Id_Facilidad;

			select 1 as valido;
		end	else begin
			select 0 as valido;
		end
	commit tran Eliminar_Facilidades
end try
begin catch
	rollback tran Eliminar_Facilidades 
	select 0 as valido;
end catch
end 
go