USE [Caminata]
GO

/****** Object:  StoredProcedure [dbo].[SPS_SeleccionarCaminatasHabHiker]    Script Date: 15/6/2017 21:33:58: PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SPS_SeleccionarCaminatasHabHiker](
	@idhiker int
)
AS BEGIN
SELECT DISTINCT C.Nombre CNombre,C.IdCaminata, TC.Descripcion, C.Direccion, C.Fecha, C.Latitud, C.Longitud, C.Precio, IC.Imagen, 
		D.Nombre + ', ' + Ca.Nombre + ', ' + P.Nombre Lugar,Pe.Alias HAlias
	FROM CaminataXHiker CH
		inner join dbo.Hiker H
			on CH.IdHiker = H.IdHiker
		inner join dbo.Persona Pe
			on Pe.IdPersona = H.IdHiker
		inner join Caminata C
			ON CH.IdCaminata = C.IdCaminata
		left join ImagenCaminata IC
			ON C.IdImagen = IC.IdImagen 
		inner join TipoCaminata TC
			ON C.TipoCaminata = TC.IdTipo
		inner join Distrito D
			ON C.IdDistrito = D.IdDistrito
		inner join Canton Ca	
			ON D.IdCanton = Ca.IdCanton
		inner join Provincia P
			ON Ca.IdProvincia = P.IdProvincia
	WHERE ch.IdHiker = @idhiker and c.Habilitado = 1
END





GO

