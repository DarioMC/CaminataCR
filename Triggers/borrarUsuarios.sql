create trigger borrarUsuarios
on Persona
instead of delete
as
begin
	declare @fechaHora DATETIME;
	declare @tipoCambio VARCHAR(20);
	declare @objeto VARCHAR(20);
	declare @descripcion VARCHAR(100);
	declare @ID INT;
	declare @tipo VARCHAR(20);
	declare @usuario VARCHAR(20);

	set @fechaHora=GETDATE();

	select @ID=D.IdPersona, @usuario=D.Alias from deleted D

	IF EXISTS (SELECT TOP 1 * FROM Administrador A where A.IdAdministrador = @ID) 
	BEGIN
	SELECT @objeto='Administrador' 
	Delete from Administrador where Administrador.IdAdministrador=@ID
	END

	IF EXISTS (SELECT TOP 1 * FROM UsuarioICT U where U.IdUsuarioICT = @ID) 
	BEGIN
	SELECT @objeto='UsuarioICT' 
	Delete from UsuarioICT where UsuarioICT.IdUsuarioICT=@ID
	END
	
	delete from Persona where Persona.IdPersona=@ID;

	set @tipo='Borrado'

	set @descripcion = 'Se borro el ' + @objeto +': ' + @usuario

	select @descripcion, @tipo, @objeto, @fechaHora
	insert into Bitacora values (@descripcion, @tipo, @objeto, @fechaHora)
end
