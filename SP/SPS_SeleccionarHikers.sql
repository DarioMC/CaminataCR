Create procedure SPS_SeleccionarHikers
AS BEGIN
select Alias, P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, FechaNac, Cedula, IdPersona, A.CuentaBancaria, A.IdImagen from Persona P 
	inner join Hiker A 
		on A.IdHiker = P.IdPersona
END 
GO