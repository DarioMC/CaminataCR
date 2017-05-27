Create procedure SPS_AgregarNivelDificultad(
	@comentario VARCHAR(100)
)
AS BEGIN
INSERT INTO NivelDificultad(Descripcion) values (@comentario)
END 
GO