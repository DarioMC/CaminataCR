USE [Caminata];
CREATE TABLE [NivelDificultad]
(
	[Nivel] INT NOT NULL,
	[IdCaminata] INT NOT NULL,
	CONSTRAINT [PK_IdCaminata] PRIMARY KEY (IdCaminata),
	CONSTRAINT [FK_NivelDificultad_Caminata] FOREIGN KEY([IdCaminata]) REFERENCES [dbo].[Caminata] ([IdCaminata]),
)
