USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_InactivarUsuarioRegular]    Script Date: 5/6/2017 23:32:48: PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SPS_InactivarUsuarioRegular](
	@alias varchar(50)  
)
AS   
	UPDATE Hiker
	SET Habilitado = 0
	FROM Hiker AS H
		inner join Persona AS P
		ON H.IdHiker = P.IdPersona
	WHERE P.Alias = @alias

GO
