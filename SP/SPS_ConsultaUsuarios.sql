USE [Caminata]
GO

/****** Object:  StoredProcedure [dbo].[SPS_ConsultaUsuarios]    Script Date: 15/6/2017 20:01:28: PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPS_ConsultaUsuarios](
@nombre VARCHAR(50) = null, @apellido VARCHAR(50) = null, @cantLikes INT = null, @true BIT = 1
)
AS
BEGIN
declare @ExecStr NVARCHAR(MAX), @GB VARCHAR(2000) = N'group by PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, IH.Imagen, CuentaBancaria '

SET @ExecStr = N'select PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, IH.Imagen, 
		CuentaBancaria, Count(DISTINCT CH.IdCaminata) as "Cantidad Caminatas", Count(DISTINCT E.NSecuencia) as "Puntos Geograficos",
		Count(DISTINCT L.IdLike) as Likes
from Persona P 
	inner join Hiker H on P.IdPersona = H.IdHiker
	left join ImagenHiker IH on H.IdImagen = IH.IdImagen
	inner join CaminataXHiker CH on H.IdHiker = CH.IdHiker
	inner join Caminata C on CH.IdCaminata = C.IdCaminata
	inner join Evento E on E.IdCaminata = C.IdCaminata
	inner join "Like" L on L.IdEvento = E.IdEvento
where @true = 1 '
	if (@nombre is not null)
		SET @ExecStr = @ExecStr + ' and PrimerNombre like ''%''+@nombre+''%'' ' 
	if (@apellido is not null)
		SET @ExecStr = @ExecStr + ' and PrimerApellido like ''%''+@apellido+''%'' '  
	if(@cantLikes is not null)
		SET @ExecStr = @ExecStr + @GB + N'Having Count(DISTINCT L.IdLike) >= @cantLikes'
	Else
		SET @ExecStr = @ExecStr + @GB
		print @ExecStr
		exec sp_executesql @ExecStr, N'@nombre VARCHAR(50), @apellido VARCHAR(50), @cantLikes INT, @true BIT', @nombre, @apellido, @cantLikes,@true
		
END
GO

