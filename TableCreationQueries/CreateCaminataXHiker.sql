USE [Caminata];
CREATE TABLE [CaminataXHiker]
(
	[IdHiker] INT NOT NULL,
	[IdCaminata] INT NOT NULL,
	CONSTRAINT [PK_CaminataXHiker] PRIMARY KEY (IdHiker,IdCaminata),
	CONSTRAINT [FK_CaminataXHiker_IdHiker] FOREIGN KEY([IdHiker]) REFERENCES [dbo].[Hiker] ([IdPersona]),
    CONSTRAINT [FK_CaminataXHiker_IdCaminata] FOREIGN KEY([IdCaminata]) REFERENCES [dbo].[Caminata] ([IdCaminata])
)
