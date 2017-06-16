USE [Caminata]
GO

/****** Object:  StoredProcedure [dbo].[SPS_GustosRutasXCaminata]    Script Date: 15/6/2017 23:40:25: PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPS_GustosRutasXCaminata](
@idCaminata INT
)
AS
BEGIN
DECLARE @ExecStr NVARCHAR(MAX), 
@GB VARCHAR(MAX) = N'group by C.Nombre, C.Direccion, D.Nombre, Ca.Nombre, P.Nombre, C.Fecha, C.Latitud, C.Longitud, 
		TC.Descripcion, IC.Imagen, C.Precio, C.Habilitado, E.NSecuencia, E.Latitud, E.Longitud,
		E.Comentario, IE.Imagen, NC.Descripcion, ND.Descripcion, NP.Descripcion '

SET @ExecStr = N'Select DISTINCT C.Nombre, D.Nombre + '', '' + Ca.Nombre + '', '' + P.Nombre Lugar, C.Fecha, C.Latitud "Latitud Caminata", C.Longitud "Longitud Caminata", 
		TC.Descripcion "Tipo Caminata", IC.Imagen "Imagen Caminata", C.Precio, C.Habilitado, E.NSecuencia "Punto Reportado", E.Latitud "Latitud Punto", E.Longitud "Longitud Punto",
		E.Comentario, IE.Imagen "Imagen evento", NC.Descripcion Calidad, ND.Descripcion Dificultad, NP.Descripcion Precio
from Caminata C 
	inner join Evento E ON C.IdCaminata = E.IdCaminata
	inner join TipoCaminata TC ON C.TipoCaminata = TC.IdTipo
	left join ImagenCaminata IC ON C.IdImagen = IC.IdImagen
	left join ImagenEvento IE ON E.IdImagen = IE.IdImagen
	inner join Distrito D ON C.IdDistrito = D.IdDistrito
	inner join Canton Ca ON D.IdDistrito = Ca.IdCanton
	inner join Provincia P ON P.IdProvincia = Ca.IdProvincia
	inner join ReviewXHiker RH ON C.IdCaminata = RH.IdCaminata
	inner join NivelCalidad NC ON RH.IdNivelCalidad = NC.IdNivelCalidad
	inner join NivelDificultad ND ON RH.IdNivelDificultad = ND.Nivel
	inner join NivelPrecio NP ON RH.IdNivelPrecio = NP.IdNivelPrecio
where C.IdCaminata = @idCaminata '

	exec sp_executesql @ExecStr, N'@idCaminata INT', @idCaminata
END
GO

