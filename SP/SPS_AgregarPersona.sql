CREATE PROCEDURE dbo.SPS_AgregarPersona(
	@primerNombre varchar(50),
	@primerApellido varchar(50),
	@segundoApellido varchar(50),
	@fechaNac date,
	@alias varchar(50),
	@contrasena varchar(200),
	@cedula varchar(20)
)
AS BEGIN 
	DECLARE @idPersona  int 
	INSERT INTO dbo.Persona(
	PrimerNombre,
	PrimerApellido,
	SegundoApellido,
	FechaNac,
	Alias,
	Contrasena,
	Cedula )VALUES(
	@primerNombre,
	@primerApellido,
	@segundoApellido,
	@fechaNac,
	@alias,
	@contrasena,
	@cedula
	);
	SET @idPersona = @@IDENTITY;
	RETURN @idPersona;

END
