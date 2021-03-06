USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_GustosRutasXCaminata]    Script Date: 16/6/2017 03:08:51: AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPS_GustosRutasXCaminata](
@idCaminata INT
)
AS
BEGIN
DECLARE @ExecStr NVARCHAR(MAX)

SET @ExecStr = N'Select DISTINCT C.Nombre, E.NSecuencia "Punto Reportado", E.Latitud "Latitud Punto", E.Longitud "Longitud Punto",
		E.Comentario, IE.Imagen "Imagen evento"
from Caminata C 
	inner join Evento E ON C.IdCaminata = E.IdCaminata
	left join ImagenEvento IE ON E.IdImagen = IE.IdImagen
where C.IdCaminata = @idCaminata '

	exec sp_executesql @ExecStr, N'@idCaminata INT', @idCaminata
END