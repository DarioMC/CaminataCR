USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_BorrarTipoCaminata]    Script Date: 5/6/2017 23:32:48: PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SPS_BorrarTipoCaminata](
	@idPk int
)
AS
DELETE TipoCaminata
WHERE IdTipo = @idPk

GO
