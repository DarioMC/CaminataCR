USE [Caminata];
CREATE TABLE [NivelCalidad]
(
	[Nivel]INT NOT NULL,
	[IdCaminata] INT NOT NULL,
	CONSTRAINT [PK_NivelCalidad] PRIMARY KEY (Nivel),
	CONSTRAINT [FK_NivelCalidad_Caminata] FOREIGN KEY([IdCaminata]) REFERENCES [dbo].[Caminata] ([IdCaminata]),
)
