

CREATE PROCEDURE dbo.[SPS_HabilitarNivelesCalidad](
@idCalidad INT
)
AS 
BEGIN

Update NivelCalidad
SET Habilitado = 1
WHERE IdNivelCalidad = @idCalidad

END
