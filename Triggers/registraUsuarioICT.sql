create trigger registraUsuarioICT
on UsuarioICT
after insert
as
begin
	declare @fechaHora DATETIME;
	declare @tipoCambio VARCHAR(20);
	declare @objeto VARCHAR(20);
	declare @descripcion VARCHAR(100);
	declare @ID INT;
	declare @tipo VARCHAR(20);
	declare @usuario VARCHAR(20);

	set @fechaHora=GETDATE();

	select @ID=P.IdPersona, @usuario=P.Alias from inserted I inner join Persona P on I.IdUsuarioICT=P.IdPersona

	set @objeto='UsuarioICT' 

	set @tipo='Registro'

	set @descripcion = 'Agrego el ' + @objeto +': ' + @usuario

	insert into Bitacora values (@descripcion, @tipo, @objeto, @fechaHora)
end