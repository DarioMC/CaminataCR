USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_EditarTipoCaminata]    Script Date: 5/6/2017 23:32:48: PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SPS_EditarTipoCaminata](
	@idPk int,
	@descripcion varchar(100)
)
AS

UPDATE TipoCaminata
SET Descripcion = @descripcion
WHERE IdTipo = @idPk


GO
