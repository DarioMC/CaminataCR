USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_GustosRutasXLikes]    Script Date: 16/6/2017 12:04:46: PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SPS_GustosRutasXLikes](
@top INT = 50, @orden BIT = 0, @fecha1 DATETIME, @fecha2 DATETIME
)
AS
BEGIN
DECLARE @ExecStr NVARCHAR(MAX)
SET @ExecStr= N'Select DISTINCT Top(@top) C.Nombre, Count(DISTINCT L.IdLike) Likes, C.IdCaminata, C.Direccion, D.Nombre + '', '' + Ca.Nombre + '', '' + P.Nombre Lugar,
		 C.Fecha, C.Latitud, C.Longitud, TC.Descripcion, IC.Imagen, C.Precio, C.Habilitado
from Caminata C
	inner join Evento E ON C.IdCaminata = E.IdCaminata
	inner join TipoCaminata TC ON C.TipoCaminata = TC.IdTipo
	left join ImagenCaminata IC ON C.IdImagen = IC.IdImagen
	left join "Like" L ON L.IdEvento = E.IdEvento
	inner join Distrito D ON C.IdDistrito = D.IdDistrito
	inner join Canton Ca ON D.IdDistrito = Ca.IdCanton
	inner join Provincia P ON P.IdProvincia = Ca.IdProvincia
		
where C.Fecha Between @fecha1 AND @Fecha2
Group by C.Nombre, C.IdCaminata, C.Direccion, D.Nombre, Ca.Nombre, P.Nombre, C.Fecha, C.Latitud, C.Longitud, TC.Descripcion,
IC.Imagen, C.Precio, C.Habilitado '
	If(@orden = 0)
		SET @ExecStr = @ExecStr + 'Order by Likes DESC'
	Else
		SET @ExecStr = @ExecStr + 'Order by Likes ASC'

	exec sp_executesql @ExecStr, N'@top INT = 50, @orden BIT = 0, @fecha1 DATETIME, @fecha2 DATETIME', @top, @orden, @fecha1, @fecha2

END