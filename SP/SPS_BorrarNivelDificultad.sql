USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_BorrarNivelDificultad]    Script Date: 5/6/2017 23:32:47: PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SPS_BorrarNivelDificultad](
	@idPk int
)
AS
DELETE NivelDificultad
WHERE Nivel = @idPk

GO
