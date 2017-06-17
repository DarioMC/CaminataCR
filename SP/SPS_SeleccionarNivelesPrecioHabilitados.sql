create procedure [dbo].[SPS_SeleccionarNivelesPrecioHabilitados]
AS BEGIN
select * from NivelPrecio where Habilitado=1
END 
