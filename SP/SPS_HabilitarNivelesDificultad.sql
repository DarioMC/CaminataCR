

CREATE PROCEDURE dbo.[SPS_HabilitarNivelesDificultad](
@idDificultad INT
)
AS 
BEGIN

Update NivelDificultad
SET Habilitado = 1
WHERE Nivel = @idDificultad

END
