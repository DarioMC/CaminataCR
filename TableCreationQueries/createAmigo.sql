USE [Caminata];
CREATE TABLE [Amigo]
(
	[IdHiker1] INT  NOT NULL, 
    [IdHiker2] INT NOT NULL, 

	 CONSTRAINT [FK_Hiker_IdPersona1] FOREIGN KEY([IdHiker1]) REFERENCES [dbo].[Hiker] ([IdHiker]),
	 CONSTRAINT [FK_Hiker_IdPersona2] FOREIGN KEY([IdHiker2]) REFERENCES [dbo].[Hiker] ([IdHiker]),
	 CONSTRAINT [PK_Amigo] PRIMARY KEY (IdHiker1,IdHiker2)
)