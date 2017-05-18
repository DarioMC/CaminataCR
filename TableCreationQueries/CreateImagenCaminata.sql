USE [Caminata];
CREATE TABLE [dbo].[ImagenCaminata]
(
	[IdImagen] INT IDENTITY(1,1) NOT NULL,
    [IdCaminata] INT NOT NULL, 
	[Imagen] IMAGE NOT NULL,
	CONSTRAINT [FK_Imagen_IdCaminata] FOREIGN KEY([IdCaminata]) REFERENCES [dbo].[Caminata] ([IdCaminata]),
	CONSTRAINT [PK_Caminata_Imagen] PRIMARY KEY (IdImagen)

)