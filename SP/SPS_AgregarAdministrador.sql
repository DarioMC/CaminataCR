Create procedure SPS_AgregarAdministrador(
	@primerNombre varchar(50),
	@primerApellido varchar(50),
	@segundoApellido varchar(50),
	@fechaNac date,
	@alias varchar(50),
	@contrasena varchar(200),
	@cedula varchar(20)
)
AS BEGIN
	DECLARE @idPersona int  
	EXECUTE @idPersona = SPS_AgregarPersona
		@primerNombre = @primerNombre,
		@primerApellido = @primerApellido,
		@segundoApellido = @segundoApellido,
		@fechaNac = @fechaNac,
		@alias = @alias,
		@contrasena = @contrasena,
		@cedula= @cedula
	
	INSERT INTO dbo.Administrador(
	IdAdministrador
	)VALUES(
		@idPersona
	)	
END 
GO