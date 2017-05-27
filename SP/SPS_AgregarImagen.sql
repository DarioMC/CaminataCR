Create procedure SPS_AgregarImagen(
	@foto varbinary(MAX)
)
AS BEGIN
	DECLARE @idImagen int
	INSERT INTO dbo.Imagen(Foto)VALUES(@foto)
	SET @idImagen = @@IDENTITY
	RETURN @idImagen
		
END 