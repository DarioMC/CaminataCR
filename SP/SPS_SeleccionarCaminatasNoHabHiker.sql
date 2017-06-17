USE [Caminata]
GO

/****** Object:  StoredProcedure [dbo].[SPS_SeleccionarCaminatasNoHabHiker]    Script Date: 15/6/2017 21:34:18: PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPS_SeleccionarCaminatasNoHabHiker] (
@idCaminata int
)
AS BEGIN
SELECT DISTINCT C.Nombre CNombre,TC.Descripcion, C.Direccion, C.Fecha, C.Latitud, C.Longitud, C.Precio, IC.Imagen, 
		D.Nombre + Ca.Nombre + P.Nombre Lugar, NC.Descripcion, ND.Descripcion, NP.Descripcion
	FROM (Select AVG(IdNivelCalidad) Calidad from ReviewXHiker where IdCaminata = @idCaminata) A inner join NivelCalidad NC
			ON A.Calidad = NC.IdNivelCalidad,
	(Select AVG(IdNivelDificultad) Dificultad from ReviewXHiker where IdCaminata = @idCaminata) B inner join NivelDificultad ND
			ON B.Dificultad = ND.Nivel,
	(Select AVG(IdNivelPrecio) Precio from ReviewXHiker where IdCaminata = @idCaminata) Z inner join NivelPrecio NP
			ON Z.Precio = NP.IdNivelPrecio,
	Caminata C
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
		inner join ReviewXHiker RH
			ON C.IdCaminata = RH.IdCaminata
		
where  C.Habilitado = 0 and C.IdCaminata = @idCaminata
END



GO

