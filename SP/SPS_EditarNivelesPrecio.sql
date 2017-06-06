USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_EditarNivelesPrecio]    Script Date: 5/6/2017 23:32:48: PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SPS_EditarNivelesPrecio](
	@idPk int,
	@descripcion varchar(100)
)
AS

UPDATE NivelPrecio
SET Descripcion = @descripcion
WHERE IdNivelPrecio = @idPk


GO
