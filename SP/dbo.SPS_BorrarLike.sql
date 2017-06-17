Create PROCEDURE dbo.SPS_BorrarLike(
	@idhiker  int,
	@idevento int
)
AS BEGIN
DELETE "Likes"
WHERE IdHiker = @idhiker AND IdEvento = @idevento 

END