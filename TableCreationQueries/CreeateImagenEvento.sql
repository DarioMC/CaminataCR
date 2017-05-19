USE [Caminata];
CREATE TABLE [ImagenEvento]
(
	[IdImagen] INT IDENTITY(1,1) NOT NULL,
	[Imagen]   IMAGE NOT NULL ,
	CONSTRAINT [PK_Evento_IdImagen] PRIMARY KEY (IdImagen),

)
