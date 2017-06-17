CREATE PROCEDURE dbo.SPS_UnirseCaminata(
@idCaminata int, @hiker int
)
AS
BEGIN

Insert into CaminataXHiker(IdCaminata, IdHiker)
Values (@idCaminata, @hiker)

END

