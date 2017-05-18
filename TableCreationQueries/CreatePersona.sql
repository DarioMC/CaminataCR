USE [Caminata];
CREATE TABLE [Persona]
(
	[IdPersona] INT IDENTITY(1,1) NOT NULL, 
    [PrimerNombre] VARCHAR(50) NOT NULL, 
    [PrimerApellido] VARCHAR(50) NOT NULL, 
    [SegundoApellido] VARCHAR(50) NULL, 
	[FechaNac] DATE  NOT NULL,
    [Alias] VARCHAR(50) NOT NULL, 
    [Contrasena] VARCHAR(20) NOT NULL, 
    [Cedula] INT NOT NULL,
	CONSTRAINT [PK_IdPersona] PRIMARY KEY (IdPersona)
) 