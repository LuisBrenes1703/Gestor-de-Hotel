use Proyecto_Ingenieria_JLGS
---------------------------------------------------------
create procedure Sp_ver_sobre_nosotros
	
as begin
begin try
	begin tran ver_sobre_nosotros
	if exists(select*from T_Hotel)begin 		
		Select  1 as valido, T_Hotel.TN_Id_Hotel,T_Hotel.TC_SobreNosotros from  T_Hotel	
	end else begin 
		select 0 as valido;
	end
	commit tran ver_sobre_nosotros
end try
begin catch
	rollback tran ver_sobre_nosotros
	select 0 as valido;
end catch
end
go
---------------------------------------------------
create procedure Sp_modificar_sobreNosotros
	@TN_Id_Hotel int,
	@TC_SobreNosotros varchar(1000)
as begin
begin try
	begin tran modificar_sobreNosotros
	if exists(select*from T_Hotel where T_Hotel.TN_Id_Hotel=@TN_Id_Hotel)begin 	
		update T_Hotel set TC_SobreNosotros=@TC_SobreNosotros where T_Hotel.TN_Id_Hotel=@TN_Id_Hotel
		Select  1 as valido
	end else begin 
		select 0 as valido;
	end
	commit tran modificar_sobreNosotros
end try
begin catch
	rollback tran modificar_sobreNosotros
	select 0 as valido;
end catch
end
go
------------------------------------------
create procedure Sp_agregar_fotoGaleria
	@TC_URL_IMG varchar(1000)
as begin
begin try
	begin tran Agregar_FotoGaleria
	if exists(select*from T_Galeria)begin 				
		INSERT INTO T_Galeria (TC_URL_IMG) VALUES (@TC_URL_IMG);
		select 1 as valido;
	end else begin
		select 0 as valido;
	end
	commit tran Agregar_FotoGaleria
end try
begin catch
	rollback tran Agregar_FotoGaleria
	select 0 as valido;
end catch
end
go
-------------------------------------------------
create procedure Sp_eliminar_fotoGaleria
	@TN_Id_Galeria int
as begin
begin try
	begin tran Eliminar_FotoGaleria
	if exists(select*from T_Galeria)begin 						
		DELETE FROM T_Galeria WHERE TN_Id_Galeria = @TN_Id_Galeria;
		select 1 as valido;
	end else begin
		select 0 as valido;
	end
	commit tran Eliminar_FotoGaleria
end try
begin catch
	rollback tran Eliminar_FotoGaleria
	select 0 as valido;
end catch
end
go
-------------------------------------------------------
create procedure sp_SobreNosotros
as 
begin
	begin try
	
	Select TC_SobreNosotros from T_Hotel;

	end try

	begin catch

	declare @ErrorMessage nvarchar(4000),  @ErrorSeverity int;
    select @ErrorMessage = ERROR_MESSAGE(),@ErrorSeverity = ERROR_SEVERITY();
    raiserror(@ErrorMessage, @ErrorSeverity, 1);
	-- control de error
	end catch
end
-------------------------------------------------
create procedure sp_Galeria
as 
begin
	begin try
	
	Select TC_URL_IMG from T_Galeria;

	end try

	begin catch

	declare @ErrorMessage nvarchar(4000),  @ErrorSeverity int;
    select @ErrorMessage = ERROR_MESSAGE(),@ErrorSeverity = ERROR_SEVERITY();
    raiserror(@ErrorMessage, @ErrorSeverity, 1);
	-- control de error
	end catch

end