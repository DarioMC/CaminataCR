create trigger registraNivelDificultad
on NivelDificultad
after insert
as
begin
	declare @fechaHora DATETIME;
	declare @tipoCambio VARCHAR(20);
	declare @objeto VARCHAR(40);
	declare @descripcion VARCHAR(100);
	declare @ID INT;
	declare @tipo VARCHAR(20);
	declare @usuario VARCHAR(20);

	set @fechaHora=GETDATE();

	select @ID=I.Nivel, @usuario=I.Descripcion from inserted I 

	set @objeto='NivelDificultad' 

	set @tipo='Registro'

	set @descripcion = 'Agrego el ' + @objeto +': ' + @usuario

	insert into Bitacora values (@descripcion, @tipo, @objeto, @fechaHora)
end