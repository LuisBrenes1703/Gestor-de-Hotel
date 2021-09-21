use Proyecto_Ingenieria_JLGS
---------------------------------------
create procedure Sp_Modificar_Direccion
	@TN_Id_Direccion int,
	@TC_Descripcion varchar(2000),
	@TC_LinkGoogleMaps varchar(2000)

as begin
begin try
	begin tran Modificar_Direccion
	if exists(select*from T_Direccion where TN_Id_Direccion= @TN_Id_Direccion )begin 		
		Update T_Direccion set TC_Descripcion = @TC_Descripcion, TC_LinkGoogleMaps=@TC_LinkGoogleMaps from T_Direccion where TN_Id_Direccion = @TN_Id_Direccion
		select 1 as valido;
	end else begin 
		select 0 as valido;
	end
	commit tran Modificar_Direccion
end try
begin catch
	rollback tran Modificar_Direccion
	select 0 as valido;
end catch
end
-------------------------------------------
create procedure Sp_Extraer_Direccion
	
as begin
begin try
	begin tran Extraer_Direccion
	if exists(select*from T_Direccion)begin 		
		Select * from T_Direccion
	end else begin 
		select 0 as valido;
	end
	commit tran Extraer_Direccion
end try
begin catch
	rollback tran Extraer_Direccion
	select 0 as valido;
end catch
end
go
-----------------------------------------------
create procedure sp_ComoLlegar
as 
begin
	begin try
	
	Select TC_Descripcion, TC_LinkGoogleMaps from T_Direccion;

	end try

	begin catch

	declare @ErrorMessage nvarchar(4000),  @ErrorSeverity int;
    select @ErrorMessage = ERROR_MESSAGE(),@ErrorSeverity = ERROR_SEVERITY();
    raiserror(@ErrorMessage, @ErrorSeverity, 1);
	-- control de error
	end catch

end