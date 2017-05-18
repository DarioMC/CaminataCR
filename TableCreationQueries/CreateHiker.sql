USE [Caminata];
CREATE TABLE [Hiker]
(
	[IdPersona] INT NOT NULL,
	[CuentaBancaria] INT NOT NULL,
	[IdImagen] INT NOT NULL,
	CONSTRAINT [PK_Hiker_IdPersona] PRIMARY KEY (IdPersona),
	CONSTRAINT [FK_Hiker_IdImagen] FOREIGN KEY([IdImagen]) REFERENCES [dbo].[Imagen] ([IdImagen]),
    CONSTRAINT [FK_Hiker_IdPersona] FOREIGN KEY([IdPersona]) REFERENCES [dbo].[Persona] ([IdPersona])
)
