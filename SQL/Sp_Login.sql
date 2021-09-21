use Proyecto_Ingenieria_JLGS
------------------------------
create procedure Sp_Login_Usuario
@TC_Usuario varchar(100),
@TC_Contrasenna varchar(50)
as begin
begin try
	begin tran Login_Usuario
	if exists(select*from T_Usuario where T_Usuario.TC_Usuario=@TC_Usuario and dbo.DESENCRIPTA_PASS(T_Usuario.TC_Contrasenna)=@TC_Contrasenna and T_Usuario.TB_Eliminado=0 and T_Usuario.TB_Activo=1)begin
		select T_Usuario.TC_Usuario, T_Puesto.TN_Id_Permiso, 1 as valido from T_Usuario 
		inner join T_Puesto on T_Usuario.TN_Id_Puesto=T_Puesto.TN_Id_Puesto
		where T_Usuario.TC_Usuario=@TC_Usuario COLLATE SQL_Latin1_General_CP1_CS_AS and dbo.DESENCRIPTA_PASS(T_Usuario.TC_Contrasenna)=@TC_Contrasenna and T_Usuario.TB_Eliminado=0 and T_Usuario.TB_Activo=1;
	end else begin
		select '' as TC_Usuario,'' as TC_Nombre_Rol, '' as TN_Id_Permiso,0 as valido
	end
	commit tran Login_Usuario
end try
begin catch
	rollback tran Login_Usuario
	select '' as TC_Usuario,'' as TC_Nombre_Rol, '' as TN_Id_Permiso,0 as valido
end catch

end
go