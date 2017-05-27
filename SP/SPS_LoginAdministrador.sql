CREATE PROCEDURE SPS_LoginAdministrador(
	@alias varchar(50),
	@contrasena varchar(200)
)
AS
BEGIN
      
      DECLARE @UserId INT
	  DECLARE @conectado INT
	  
      SELECT @UserId = IdAdministrador
      FROM dbo.Administrador A
	  INNER JOIN dbo.Persona P
		ON A.IdAdministrador = P.IdPersona
	  WHERE Alias = @alias AND Contrasena = @contrasena
     
      IF @UserId IS NOT NULL
      BEGIN
            SET @conectado = 1
      END
      ELSE
      BEGIN
            SET @conectado = 0
      END
	  RETURN @conectado
END