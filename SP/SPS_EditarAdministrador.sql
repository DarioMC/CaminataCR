USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_EditarAdministrador]    Script Date: 5/6/2017 23:32:48: PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SPS_EditarAdministrador](
	@primerNombre varchar(50),
	@primerApellido varchar(50),
	@segundoApellido varchar(50),
	@fechaNac date,
	@alias varchar(50),
	@contrasena varchar(200),
	@cedula varchar(20)
)
AS
UPDATE Persona
SET PrimerNombre = @primerNombre, PrimerApellido = @primerApellido, SegundoApellido = @segundoApellido,
	FechaNac = @fechaNac, Contrasena = @contrasena, Cedula = @cedula
WHERE Alias = @alias
GO
