CREATE PROCEDURE SPS_ExisteAlias(
	@alias varchar(50)
)
AS
BEGIN
      
      DECLARE @UserId INT
	  DECLARE @existe INT
      SELECT @UserId = IdPersona
      FROM dbo.Persona WHERE Alias = @alias 
     
      IF @UserId IS NOT NULL
      BEGIN
			SET @existe = 1   
      END
      ELSE
      BEGIN
            SET @existe = 0
      END
	  RETURN @existe
END