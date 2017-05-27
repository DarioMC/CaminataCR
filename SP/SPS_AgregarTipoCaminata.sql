Create procedure SPS_AgregarTipoCaminata(
	@comentario VARCHAR(100)
)
AS BEGIN
INSERT INTO TipoCaminata(Descripcion) values (@comentario)
END 
GO