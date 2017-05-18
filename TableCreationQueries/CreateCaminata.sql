USE [Caminata];
ALTER  TABLE [Caminata]

	ADD [IdImagen] INT NOT NULL,
    CONSTRAINT [FK_Caminata_Imagen] FOREIGN KEY([IdImagen]) REFERENCES [dbo].[ImagenCaminata] ([IdImagen])
	

