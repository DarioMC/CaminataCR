USE [Caminata];
CREATE TABLE [NivelPrecio]
(
	[Nivel]INT NOT NULL,
	[IdCaminata] INT NOT NULL,
	CONSTRAINT [PK_NivelPrecio] PRIMARY KEY (Nivel),
	CONSTRAINT [FK_NivelPrecio_Caminata] FOREIGN KEY([IdCaminata]) REFERENCES [dbo].[Caminata] ([IdCaminata]),
)
