CREATE PROCEDURE [dbo].[SPS_LikeEvento](
	@idhiker  int,
	@idevento int
	)
AS BEGIN
	INSERT INTO dbo.Likes (IdHiker, IdEvento) values (@idhiker, @idevento)
END
