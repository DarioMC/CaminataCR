create trigger editarUsuarios
on Persona
after update
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
	END

	IF EXISTS (SELECT TOP 1 * FROM UsuarioICT U where U.IdUsuarioICT = @ID) 
	BEGIN
	SELECT @objeto='UsuarioICT' 
	END
	
	set @tipo='Actualizacion'

	set @descripcion = 'Se actualizo el ' + @objeto +': ' + @usuario

	insert into Bitacora values (@descripcion, @tipo, @objeto, @fechaHora)
end
