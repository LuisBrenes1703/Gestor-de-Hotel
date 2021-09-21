use Proyecto_Ingenieria_JLGS
------------------------------------
/***************Encriptar***************/
create function ENCRIPTA_PASS
(@clave varchar(50))
	returns VarBinary(500)
	as 
	begin
		declare @TC_Contrasenna as VarBinary(500)
		set @TC_Contrasenna=ENCRYPTBYPASSPHRASE('clave',@clave)
		return @TC_Contrasenna
end
go
/**************Desencriptar**************/
create function DESENCRIPTA_PASS
(@clave varbinary(500))
	returns varchar(50)
	as
	begin
		declare @TC_Contrasenna as varchar(50)
		set @TC_Contrasenna=DECRYPTBYPASSPHRASE('clave',@clave)
		return @TC_Contrasenna
end
go