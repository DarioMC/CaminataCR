USE [Caminata];
CREATE TABLE [TipoCaminata]
(
	
	[Tipo] VARCHAR(50) NOT NULL,
	[IdTipo] INT IDENTITY(1,1) NOT NULL,
	CONSTRAINT [PK_TipoCaminata] PRIMARY KEY (IdTipo),

)
