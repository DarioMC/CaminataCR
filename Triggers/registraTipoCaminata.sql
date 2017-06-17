create trigger registraTipoCaminata
on TipoCaminata
after insert
as
begin
	declare @fechaHora DATETIME;;
	declare @objeto VARCHAR(40);
	declare @descripcion VARCHAR(100);
	declare @tipo VARCHAR(20);
	declare @descrpcionNivel VARCHAR(100)

	set @fechaHora=GETDATE();

	select @descrpcionNivel=I.Descripcion from inserted I 

	set @objeto='TipoCaminata' 

	set @tipo='Registro'

	set @descripcion = 'Agrego el ' + @objeto +': ' + @descrpcionNivel

	insert into Bitacora values (@descripcion, @tipo, @objeto, @fechaHora)
end