Create PROCEDURE  [dbo].[SPS_SeleccionarMuro](
	@IDHiker int
)
AS BEGIN

select E.Comentario,E.IdCaminata, E.IdEvento,E.IdHiker,Im.Imagen, E.Latitud, E.Longitud,E.NSecuencia from(
select A.IdHiker2 as AmigoID from Amigo A where @IDHiker=A.IdHiker1
Union
select A.IdHiker1 as AmigoID from Amigo A where @IDHiker=A.IdHiker2
) Am
inner join Likes L
	on Am.AmigoID=L.IdHiker
inner join Evento E
	on L.IdEvento=E.IdEvento
left join ImagenEvento Im
	on Im.IdImagen=E.IdImagen
End
GO