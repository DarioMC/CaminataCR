create trigger editarTipoCaminata
on TipoCaminata
after update
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

	select @ID=I.IdTipo, @descrpcionNivel=I.Descripcion from deleted I 

	set @objeto='TipoCaminata' 

	set @tipo='Actualizacion'

	set @descripcion = 'Actualizo el ' + @objeto +': ' + @descrpcionNivel

	insert into Bitacora values (@descripcion, @tipo, @objeto, @fechaHora)
end