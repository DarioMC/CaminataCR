create procedure [dbo].[SPS_SeleccionarNivelesCalidadHabilitados]
AS BEGIN
select * from NivelCalidad where Habilitado=1
END 