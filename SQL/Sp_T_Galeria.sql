use Proyecto_Ingenieria_JLGS
---------------------------------------------------
create procedure Sp_ver_galeria
	
as begin
begin try
	begin tran ver_galeria
	if exists(select*from T_Galeria)begin 		
		Select  1 as valido, T_Galeria.TN_Id_Galeria,T_Galeria.TC_URL_IMG from  T_Galeria	
	end else begin 
		select 0 as valido;
	end
	commit tran ver_galeria
end try
begin catch
	rollback tran ver_galeria
	select 0 as valido;
end catch
end
go
---------------------------------------------------