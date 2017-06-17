



CREATE PROCEDURE [dbo].[SPS_VerEventos](
@idHiker INT
)
AS BEGIN

Select C.Nombre, E.NSecuencia "Punto", IE.Imagen, E.Comentario, E.Latitud, E.Longitud,E.IdEvento, COUNT(DISTINCT L.IdLike) Likes
from Evento E 
	left join ImagenEvento IE ON E.IdImagen = IE.IdImagen
	inner join Caminata C ON E.IdCaminata = C.IdCaminata
	left join "Like" L ON E.IdEvento = L.IdEvento
where E.IdHiker = @idHiker
group by C.Nombre, E.NSecuencia, IE.Imagen, E.Comentario, E.Latitud, E.Longitud,E.IdEvento
	
END
