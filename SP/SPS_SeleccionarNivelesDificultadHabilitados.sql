create procedure [dbo].[SPS_SeleccionarNivelesDificultadHabilitados]
AS BEGIN
select * from NivelDificultad where Habilitado=1
END 
