Create procedure SPS_AgregarHiker(
	@primerNombre varchar(50),
	@primerApellido varchar(50),
	@segundoApellido varchar(50),
	@fechaNac date,
	@alias varchar(50),
	@contrasena varchar(200),
	@cedula varchar(20),
	@cuentaBanco varchar(20),
	@foto varbinary(MAX),
	@habilitado bit
)
AS BEGIN
	DECLARE @idPersona int
	DECLARE @idImagen int  
	EXECUTE @idPersona = SPS_AgregarPersona
		@primerNombre = @primerNombre,
		@primerApellido = @primerApellido,
		@segundoApellido = @segundoApellido,
		@fechaNac = @fechaNac,
		@alias = @alias,
		@contrasena = @contrasena,
		@cedula= @cedula


	EXECUTE @idImagen = SPS_AgregarImagen
		@foto

	INSERT INTO dbo.Hiker(
	IdHiker,
	IdImagen,
	CuentaBancaria,
	Habilitado
	)VALUES(
		@idPersona,
		@idImagen,
		@cuentaBanco,
		@habilitado
	)
	
END 
GO