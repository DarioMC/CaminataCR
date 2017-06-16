Use Caminata
go
CREATE PROCEDURE SPS_ConsultaUsuarios(
@nombre VARCHAR(50) = null, @apellido VARCHAR(50) = null, @cantLikes INT = null
)
AS 
BEGIN
declare @true bit = 1
declare @ExecStr NVARCHAR(MAX)

select @ExecStr = N'PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, IH.Imagen, 
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
		SET @ExecStr = @ExecStr + ' and PrimerNombre like ''%''+@apellido+''%'' ' 
	else 
		SET @ExecStr = @ExecStr + 'group by PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, IH.Imagen, CuentaBancaria '
	if(@cantLikes is not null)
		SET @ExecStr = @ExecStr + 'Having Count(DISTINCT L.IdLike) >= @cantLikes'

	declare @parametros NVARCHAR(2000)
		SET @parametros = N'@nombre VARCHAR(50), @apellido VARCHAR(50), @cantLikes INT'

		exec sp_executesql
			@ExecStr, @parametros, @nombre,
			@apellido, @cantLikes
END
