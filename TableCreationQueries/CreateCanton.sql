USE [Caminata];
CREATE TABLE [Canton]
(
	[IdCanton] INT IDENTITY(1,1) NOT NULL,
	[Nombre] VARCHAR(40) NOT NULL,
	[IdProvincia] INT NOT NULL,
	CONSTRAINT [PK_Canton] PRIMARY KEY (IdCanton),
	CONSTRAINT [FK_Canton_IdProvincia] FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[Hiker]](IdProvincia)
)