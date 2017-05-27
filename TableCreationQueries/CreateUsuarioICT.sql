CREATE TABLE [dbo].[UsuarioICT]
(
	[IdUsuarioICT] INT NOT NULL
    CONSTRAINT [PK_UsuarioICT_IdPersona] PRIMARY KEY CLUSTERED ([IdUsuarioICT] ASC),
	CONSTRAINT [FK_UsuarioICT_IdPersona] FOREIGN KEY ([IdUsuarioICT]) REFERENCES [dbo].[Persona] ([IdPersona])
)