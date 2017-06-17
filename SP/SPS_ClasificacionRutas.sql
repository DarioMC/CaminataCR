CREATE PROCEDURE [dbo].[SPS_ClasificacionRutas](
	@calidad BIT = null, @tipo Bit = null, @dificultad BIT = null,
	@precio BIT = null,
	@fecha1 datetime,
	@fecha2 datetime
)
AS
BEGIN
Declare @ExecStr NVARCHAR(MAX), @GB NVARCHAR(2000) = 'group by '
SET @ExecStr = N'SELECT Count(distinct L.IdLike) "Cantidad Likes", Count(Distinct C.Nombre) "Cantidad Caminatas", 
Count(DISTINCT E.IdEvento) "Cantidad Puntos"
from Caminata C 
	inner join Evento E on C.IdCaminata=E.IdCaminata
	left join "Like" L on L.IdEvento=E.IdEvento 
	inner join TipoCaminata TC on C.TipoCaminata = TC.IdTipo
	inner join ReviewXHiker RH on C.IdCaminata = RH.IdCaminata
	inner join NivelCalidad NC on RH.IdNivelCalidad = NC.IdNivelCalidad
	inner join NivelDificultad ND on RH.IdNivelDificultad = ND.Nivel
	inner join NivelPrecio NP on RH.IdNivelPrecio = Np.IdNivelPrecio
where C.Fecha BETWEEN @fecha1 and @fecha2 '
if(@calidad is not null)
	SET @ExecStr = @ExecStr + @GB + 'NC.Descripcion'
if(@dificultad is not null)
	SET @ExecStr = CASE When (@calidad is not null) then @ExecStr + ',ND.Descripcion' else Concat(@ExecStr, @GB + 'ND.Descripcion') end
if(@precio is not null)
	SET  @ExecStr = CASE When @dificultad is not null then Concat(@ExecStr,',NP.Descripcion') else Concat(@ExecStr, @GB + 'NP.Descripcion') end
if(@tipo is not null)
	SET  @ExecStr = CASE When @precio is not null then Concat(@ExecStr,',TC.Descripcion') else Concat(@ExecStr, @GB + 'TC.Descripcion') end

	exec sp_executesql @ExecStr, N'@calidad BIT = null, @tipo Bit = null, @dificultad BIT = null, @precio BIT = null, @fecha1 datetime,	@fecha2 datetime', @calidad, @tipo, @dificultad, @precio, @fecha1, @fecha2

END
