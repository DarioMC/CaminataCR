Create PROCEDURE  [dbo].[SPS_ConsultaReporteRemuneraciones](
	@n int,
	@fechaInicio datetime,
	@fechaFinal datetime
)
AS BEGIN

select TOP(@n) P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, P.Alias, SUM(C.Monto) as MontoTotal from Persona P 
	inner join Hiker H 
		on P.IdPersona=H.IdHiker
	inner join CierreDiario C
		on H.IdHiker=C.IdHiker
	where C.Fecha BETWEEN @fechaInicio AND @fechaFinal
	group by P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, P.Alias

END

GO