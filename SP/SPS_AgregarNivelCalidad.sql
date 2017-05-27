Create procedure SPS_AgregarNivelCalidad(
	@comentario VARCHAR(100)
)
AS BEGIN
INSERT INTO NivelCalidad(Descripcion) values (@comentario)
END 
GO