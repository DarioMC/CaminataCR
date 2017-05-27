Create procedure SPS_AgregarNivelPrecio(
	@comentario VARCHAR(100)
)
AS BEGIN
INSERT INTO NivelPrecio(Descripcion) values (@comentario)
END 
GO