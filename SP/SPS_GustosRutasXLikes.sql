USE [Caminata]
GO
/****** Object:  StoredProcedure [dbo].[SPS_GustosRutasXLikes]    Script Date: 16/6/2017 01:51:45: AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SPS_GustosRutasXLikes](
@top INT = 50, @orden BIT = 0
)
AS
BEGIN
DECLARE @ExecStr NVARCHAR(MAX)

SET @ExecStr= N'Select Top(10) C.Nombre, Count(DISTINCT L.IdLike) Likes, C.IdCaminata
from Caminata C
	inner join Evento E ON C.IdCaminata = E.IdCaminata
	left join "Like" L ON L.IdEvento = E.IdEvento
Group by C.Nombre, C.IdCaminata '
	If(@orden = 0)
		SET @ExecStr = @ExecStr + 'Order by Likes DESC'
	Else
		SET @ExecStr = @ExecStr + 'Order by Likes ASC'

	exec sp_executesql @ExecStr, N'@top INT = 50, @orden BIT = 0', @top, @orden

END