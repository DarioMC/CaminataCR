Create PROCEDURE  [dbo].[SPS_SeleccionarBitacora](
	@fechaInicio datetime,
	@fechaFinal datetime,
	@tipoAccion VARCHAR(20),
	@objeto VARCHAR(20),
	@horaInicial INT,
	@horaFinal INT
)
AS BEGIN

select B.Descripcion, B.Objeto, B.TipoAccion, B.FechaHora from Bitacora B
where  @horaInicial <= DATEPART(hour, B.FechaHora) 
	and DATEPART(hour, B.FechaHora) <= @horaFinal 
	and B.FechaHora BETWEEN @fechaInicio and @fechaFinal
	and B.Objeto=@objeto
	and B.TipoAccion=@tipoAccion
END

GO