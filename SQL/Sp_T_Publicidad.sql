use Proyecto_Ingenieria_JLGS
-----------------------------------------
create procedure Sp_Listar_Publicidad
as begin
begin try
	begin tran Listar_Publicidad
		select TN_Id_Publicidad,TC_URL_IMG,TC_LinkPublicidad from T_Publicidad
	commit tran Listar_Publicidad
end try
begin catch
	rollback tran Listar_Publicidad
	select 0 as valido;
end catch
end
go
----------------------------------------------
create procedure Sp_Obtener_Publicidad
	
as begin
begin try
	begin tran Obtener_Publicidad
	if exists(select*from T_Publicidad)begin 				
		select*from T_Publicidad;		
	end else begin
		select 0 as valido;
	end
	commit tran Obtener_Publicidad
end try
begin catch
	rollback tran Obtener_Publicidad
	select 0 as valido;
end catch
end
go
--------------------------------------------
create procedure Sp_Modificar_Publicidad
	@TN_Id_Publicidad int,
	@TC_LinkPublicidad varchar(1000),
	@TC_URL_IMG varchar(1000)

as begin
begin try
	begin tran Modificar_Publicidad
	if exists(select*from T_Publicidad)begin 						
		Update T_Publicidad set TC_LinkPublicidad = @TC_LinkPublicidad from T_Publicidad WHERE TN_Id_Publicidad = @TN_Id_Publicidad;
		
		if(@TC_URL_IMG = 'null')begin
			select 1 as valido;
		end else begin 
			Update T_Publicidad set TC_URL_IMG = @TC_URL_IMG from T_Publicidad WHERE TN_Id_Publicidad = @TN_Id_Publicidad;			
		end
		select 1 as valido;
				
	end else begin
		select 0 as valido;
	end
	commit tran Modificar_Publicidad
end try
begin catch
	rollback tran Modificar_Publicidad
	select 0 as valido;
end catch
end
go