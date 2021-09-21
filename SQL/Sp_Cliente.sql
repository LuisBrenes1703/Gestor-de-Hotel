use Proyecto_Ingenieria_JLGS
------------------------------------------------------
create procedure Sp_Get_Cliente
@TC_Cedula varchar(100) 
as begin
begin try
	begin tran Get_CLiente
	if exists(select*from T_Cliente where T_Cliente.TC_Cedula=@TC_Cedula)begin
		select 1 as TN_Valido,T_Cliente.TC_Cedula, T_Cliente.TC_Nombre, T_Cliente.TC_Apellidos, T_Cliente.TC_Email,T_Cliente.TC_Telefono, T_Cliente.TC_Tarjeta from T_Cliente where T_Cliente.TC_Cedula=@TC_Cedula
	end
	else begin
		select 0 as TN_Valido,'' as TC_Cedula, '' as TC_Nombre, '' as TC_Apellidos, '' as TC_Email, '' as TC_Telefono, '' as TC_Tarjeta 
	end
	commit tran Get_CLiente
	end try
begin catch
	rollback tran Get_CLiente
	select 0 as TN_Valido,'' as TC_Cedula, '' as TC_Nombre, '' as TC_Apellidos, '' as TC_Email, '' as TC_Telefono, '' as TC_Tarjeta 
end catch
end
go
--------------------------------------------
create procedure Sp_Insert_Cliente
@TC_Cedula varchar(100),
@TC_Nombre varchar(100),
@TC_Apellidos varchar(100),
@TC_Email varchar(100),
@TC_Telefono varchar(100),
@TC_Tarjeta varchar(16)
as begin
begin try
	begin tran Insert_Cliente
	if not exists(select*from T_Cliente where T_Cliente.TC_Cedula=@TC_Cedula)begin
		insert into T_Cliente (TC_Cedula,TC_Nombre,TC_Apellidos,TC_Email,TC_Telefono,TC_Tarjeta) values(@TC_Cedula,@TC_Nombre,@TC_Apellidos,@TC_Email,@TC_Telefono,@TC_Tarjeta)
		--select 1 as TN_Valido
	end
	commit tran Insert_Cliente
	end try
begin catch
	rollback tran Insert_Cliente
	--select 0 as TN_Valido
end catch
end
go
--------------------------------------------
create procedure sp_contactenos
as 
begin
	begin try
	
	Select [TC_Telefono], [TC_CorreoElectronico] from T_Hotel;

	end try

	begin catch

	declare @ErrorMessage nvarchar(4000),  @ErrorSeverity int;
    select @ErrorMessage = ERROR_MESSAGE(),@ErrorSeverity = ERROR_SEVERITY();
    raiserror(@ErrorMessage, @ErrorSeverity, 1);
	-- control de error
	end catch

end
----------------------------------------------------
create procedure Sp_Modificar_Contactos
	@TC_CorreoElectronico varchar(100),
	@TC_Telefono varchar(100)
as begin
begin try
	begin tran Modificar_Contactos
		if exists(select [TC_Telefono], [TC_CorreoElectronico] from T_Hotel)
			begin

			update T_Hotel set [TC_CorreoElectronico]= @TC_CorreoElectronico , [TC_Telefono]= @TC_Telefono
			 
			select 1 as valido;

		end	else begin
			select 0 as valido;
		end
	commit tran Modificar_Contactos 
end try
begin catch
	rollback tran Modificar_Contactos 
	select 0 as valido;
end catch
end 
go
