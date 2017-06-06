USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_LoginHiker]    Script Date: 5/6/2017 23:32:48: PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPS_LoginHiker](
	@alias varchar (50),
	@contrasena varchar(200)
)
AS BEGIN 
	 DECLARE @UserId INT
	  DECLARE @conectado INT
	  
      SELECT @UserId = H.IdHiker
		  FROM dbo.Hiker H
		  INNER JOIN dbo.Persona P
			ON H.IdHiker = P.IdPersona
		  WHERE Alias = @alias AND Contrasena = @contrasena
     
      IF @UserId IS NOT NULL
      BEGIN
            SET @conectado = 1
				
      END
      ELSE
      BEGIN
            SET @conectado = 0
		
      END
	 RETURN @conectado

END 


GO
