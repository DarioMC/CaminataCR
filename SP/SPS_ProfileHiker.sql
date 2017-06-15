USE [Caminata]
GO

/****** Object:  StoredProcedure [dbo].[SPS_ProfileHiker]    Script Date: 15/6/2017 00:45:31: AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[SPS_ProfileHiker](
	@alias varchar (50),
	@contrasena varchar(200)
)
AS BEGIN 
	 SELECT P.Alias ,P.Cedula,P.FechaNac,P.IdPersona,P.PrimerNombre,P.PrimerApellido,
	 P.SegundoApellido,I.Imagen,H.CuentaBancaria
	 FROM dbo.Persona P
		 INNER JOin dbo.Hiker H
		 on H.IdHiker = P.IdPersona
		 INNER JOIN dbo.ImagenHiker I
		 on H.IdImagen = I.IdImagen
	 WHERE P.Alias = @alias AND P.Contrasena = @contrasena

END 






GO

