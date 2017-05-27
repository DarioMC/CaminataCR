Create procedure SPS_SeleccionarAdministradores
AS BEGIN
select Alias, P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, FechaNac, Cedula, IdPersona from Persona P 
	inner join Administrador A 
		on A.IdAdministrador = P.IdPersona
END 
GO