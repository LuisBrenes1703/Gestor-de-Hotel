use Proyecto_Ingenieria_JLGS
---------------------------------------------------
create procedure Sp_Inicio_Hotel
as begin
begin try
	begin tran Inicio_Hotel
		select TN_Id_Hotel,TC_Inicio,TC_URL_IMG from T_Hotel
	commit tran Inicio_Hotel
end try
begin catch
	rollback tran Inicio_Hotel
	select 0 as valido;
end catch
end
go
---------------------------------------------------