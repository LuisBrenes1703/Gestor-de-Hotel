use Proyecto_Ingenieria_JLGS
----------------------------------------------
create procedure Sp_Listar_Oferta
as begin
begin try
	begin tran Listar_Oferta
		if exists (select*from T_Oferta where T_Oferta.TC_Fecha_Final>= GETDATE() and T_Oferta.TC_Fecha_Inicio<=GETDATE())begin
			select TN_Id_Oferta,TN_Id_TipoHabitacion,TC_PorcentajeOferta,TC_URL_IMG from T_Oferta where T_Oferta.TC_Fecha_Final>= GETDATE() and T_Oferta.TC_Fecha_Inicio<=GETDATE()
		end
	commit tran Listar_Oferta
end try
begin catch
	rollback tran Listar_Oferta
	select 0 as valido;
end catch
end
go
---------------------------------------------------
create procedure Sp_Agregar_Oferta
@TN_Id_TipoHabitacion int,
@TC_Fecha_Inicio date,
@TC_Fecha_Fin date,
@TC_PorcentajeOferta float,
@TC_Nombre_Oferta varchar(100),
@TC_URL_IMG varchar(1000)
as begin
begin try
	begin tran Agregar_Oferta
		if not exists(select*from T_Oferta where T_Oferta.TC_Oferta=@TC_Nombre_Oferta)begin
			if not exists(select*from T_Oferta where T_Oferta.TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion and ((T_Oferta.TC_Fecha_Inicio<=@TC_Fecha_Fin and  T_Oferta.TC_Fecha_Inicio>= @TC_Fecha_Inicio) or (T_Oferta.TC_Fecha_Final>= @TC_Fecha_Inicio and T_Oferta.TC_Fecha_Final<=@TC_Fecha_Fin)))begin
				insert into T_Oferta(TN_Id_TipoHabitacion,TC_Oferta,TC_PorcentajeOferta,TC_URL_IMG,TC_Fecha_Inicio,TC_Fecha_Final)values(@TN_Id_TipoHabitacion,@TC_Nombre_Oferta,@TC_PorcentajeOferta,@TC_URL_IMG,@TC_Fecha_Inicio,@TC_Fecha_Fin);
				select 1 as valido
			end else begin
				select 0 as valido
			end
		end else begin
			select 0 as valido
		end
	commit tran Agregar_Oferta
end try
begin catch
	rollback tran Agregar_Oferta
end catch
end
go
---------------------------------------------------
create procedure Sp_Listar_Ofertas_Nombre_Id
as begin
begin try
	begin tran Listar_Ofertas_Nombre_Id
		if  exists(select*from T_Oferta)begin
			select TN_Id_Oferta,TC_Oferta from T_Oferta
		end
	commit tran Listar_Ofertas_Nombre_Id
end try
begin catch
	rollback tran Listar_Ofertas_Nombre_Id
end catch
end
go
---------------------------------------------------
create procedure Sp_Listar_Oferta_Especifico
@TN_Id_Oferta int
as begin
begin try
	begin tran Listar_Oferta_Especifico
		if  exists(select*from T_Oferta where T_Oferta.TN_Id_Oferta=@TN_Id_Oferta)begin
			select TN_Id_Oferta,TN_Id_TipoHabitacion,TC_Oferta,TC_PorcentajeOferta,TC_URL_IMG,TC_Fecha_Inicio,TC_Fecha_Final from T_Oferta where T_Oferta.TN_Id_Oferta=@TN_Id_Oferta
		end
	commit tran Listar_Oferta_Especifico
end try
begin catch
	rollback tran Listar_Oferta_Especifico
end catch
end
go
---------------------------------------------------
create procedure Sp_Modificar_Oferta
@TN_Id_Oferta int,
@TN_Id_TipoHabitacion int,
@TC_Fecha_Inicio date,
@TC_Fecha_Fin date,
@TC_PorcentajeOferta float,
@TC_Nombre_Oferta varchar(100),
@TC_URL_IMG varchar(1000)
as begin
begin try
	begin tran Modificar_Oferta
		if not exists(select*from T_Oferta where T_Oferta.TC_Oferta=@TC_Nombre_Oferta and T_Oferta.TN_Id_Oferta!=@TN_Id_Oferta)begin
			if not exists(select*from T_Oferta where T_Oferta.TN_Id_Oferta!=@TN_Id_Oferta and T_Oferta.TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion and ((T_Oferta.TC_Fecha_Inicio<=@TC_Fecha_Fin and  T_Oferta.TC_Fecha_Inicio>= @TC_Fecha_Inicio) or (T_Oferta.TC_Fecha_Final>= @TC_Fecha_Inicio and T_Oferta.TC_Fecha_Final<=@TC_Fecha_Fin)))begin
				declare @TC_Oferta_Antiguo varchar(100)
				select @TC_Oferta_Antiguo=TC_Oferta from T_Oferta where T_Oferta.TN_Id_Oferta=@TN_Id_Oferta
				update T_Oferta set TN_Id_TipoHabitacion=@TN_Id_TipoHabitacion,TC_Oferta=@TC_Nombre_Oferta,TC_PorcentajeOferta=@TC_PorcentajeOferta,TC_URL_IMG=@TC_URL_IMG,TC_Fecha_Inicio=@TC_Fecha_Inicio,TC_Fecha_Final=@TC_Fecha_Fin where T_Oferta.TN_Id_Oferta=@TN_Id_Oferta 
				select 1 as valido, @TC_Oferta_Antiguo as TC_Oferta_Antiguo
			end else begin
				select 0 as valido, '' as TC_Oferta_Antiguo
			end
		end else begin
			select 0 as valido, '' as TC_Oferta_Antiguo
		end
	commit tran Modificar_Oferta
end try
begin catch
	rollback tran Modificar_Oferta
end catch
end
go
---------------------------------------------------
create procedure Sp_Borrar_Oferta
@TN_Id_Oferta int
as begin
begin try
	begin tran Borrar_Oferta
		if exists(select*from T_Oferta where T_Oferta.TN_Id_Oferta=@TN_Id_Oferta)begin
			declare @TC_Oferta_Antiguo varchar(100)
			select @TC_Oferta_Antiguo=TC_Oferta from T_Oferta where T_Oferta.TN_Id_Oferta=@TN_Id_Oferta
			delete T_Oferta where T_Oferta.TN_Id_Oferta=@TN_Id_Oferta
			select 1 as valido, @TC_Oferta_Antiguo as TC_Oferta_Antiguo
		end else begin
			select 0 as valido, '' as TC_Oferta_Antiguo
		end
	commit tran Borrar_Oferta
end try
begin catch
	rollback tran Borrar_Oferta
end catch
end
go
---------------------------------------------------
