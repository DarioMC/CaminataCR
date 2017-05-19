USE [Caminata];
CREATE TABLE [Evento]
(
	[IdEvento] INT IDENTITY(1,1) NOT NULL,
	[Latitud] FLOAT NOT NULL,
	[Longitud] FLOAT NOT NULL,
	[IdCaminata] INT NOT NULL,
	[Comentario] VARCHAR(50),
	[IdImagen] INT ,
	CONSTRAINT [PK_Evento] PRIMARY KEY (IdEvento),
    CONSTRAINT [FK_Evento_IdCaminata] FOREIGN KEY([IdCaminata]) REFERENCES [dbo].[Caminata] ([IdCaminata]),
	CONSTRAINT [FK_Evento_IdImagen] FOREIGN KEY([IdImagen]) REFERENCES [dbo].[ImagenEvento] ([IdImagen])
)
