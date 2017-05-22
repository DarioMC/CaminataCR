CREATE TABLE [dbo].[Administrador]
(
	[IdAdministrador] INT NOT NULL
    CONSTRAINT [PK_Administrador_IdPersona] PRIMARY KEY CLUSTERED ([IdAdministrador] ASC),
	CONSTRAINT [FK_Administrador_IdPersona] FOREIGN KEY ([IdAdministrador]) REFERENCES [dbo].[Persona] ([IdPersona])
)