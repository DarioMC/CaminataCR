USE [Caminata];
CREATE TABLE [dbo].[Imagen]
(
	[IdImagen] INT IDENTITY(1,1) NOT NULL,
    [IdPersona] INT NOT NULL, 
	[Imagen] IMAGE NOT NULL,
	CONSTRAINT [FK_Imagen_IdPersona] FOREIGN KEY([IdPersona]) REFERENCES [dbo].[Persona] ([IdPersona]),
	CONSTRAINT [PK_Imagen] PRIMARY KEY (IdImagen)

)