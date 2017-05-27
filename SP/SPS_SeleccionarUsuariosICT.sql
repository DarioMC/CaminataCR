Create procedure SPS_SeleccionarUsuariosICT
AS BEGIN
select Alias, P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, FechaNac, Cedula, IdPersona from Persona P 
	inner join UsuarioICT A 
		on A.IdUsuarioICT = P.IdPersona
END 
GO