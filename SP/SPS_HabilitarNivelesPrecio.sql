

CREATE PROCEDURE dbo.[SPS_HabilitarNivelesPrecio](
@idPrecio INT
)
AS 
BEGIN

Update NivelPrecio
SET Habilitado = 1
WHERE IdNivelPrecio = @idPrecio

END
