create trigger registraNivelPrecio
on NivelPrecio
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
	declare @descrpcionNivel VARCHAR(100)

	set @fechaHora=GETDATE();

	select @ID=I.IdNivelPrecio, @descrpcionNivel=I.Descripcion from inserted I 

	set @objeto='NivelPrecio' 

	set @tipo='Registro'

	set @descripcion = 'Agrego el ' + @objeto +': ' + @descrpcionNivel

	insert into Bitacora values (@descripcion, @tipo, @objeto, @fechaHora)
end