CREATE PROCEDURE SPS_BorrarUsuarioICT(
	@alias varchar(50)
)
AS
BEGIN

delete from dbo.Persona
where alias = @alias

end