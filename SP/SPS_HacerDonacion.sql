

CREATE PROCEDURE dbo.SPS_HacerDonacion(
@donacion INT, @idHiker INT
)
AS BEGIN
DECLARE @cuenta INT = (SELECT CuentaBancaria from Hiker where IdHiker = @idHiker)

Insert Donacion(IdHiker,MontoDonacion,Fecha,CuentaBanco)
Values(@idHiker, @donacion, GETDATE(), @cuenta)
	
END
