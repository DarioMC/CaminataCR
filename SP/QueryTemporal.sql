/*select * from Persona P inner join Administrador A on A.IdAdministrador = P.IdPersona
select Alias, P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, FechaNac, Cedula, IdPersona  from Persona P inner join Administrador A on A.IdAdministrador = P.IdPersona
/*
exec SPS_AgregarAdministrador
	@primerNombre = 'Goku',
	@primerApellido = 'Super',
	@segundoApellido = 'Saiyan',
	@fechaNac = '12-05-2017',
	@alias = 'Goku',
	@contrasena = '3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2',
	@cedula = '102340821'
*/

/*
declare @cosa int

execute @cosa = SPS_LoginAdministrador
	@alias = 'Goku',
	@contrasena = '3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2'

print @cosa
*/

select * from NivelDificultad
*/

EXEC SPS_BorrarAdministrador
@alias = 'Gogeta'