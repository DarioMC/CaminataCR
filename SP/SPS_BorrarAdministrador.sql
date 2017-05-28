CREATE PROCEDURE SPS_BorrarAdministrador(
	@alias varchar(50)
)
AS
BEGIN

delete from dbo.Persona
where alias = @alias

end