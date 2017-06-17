create procedure [dbo].[SPS_ObtenerTipos]
AS BEGIN
select T.IdTipo, T.Descripcion as Tipo from TipoCaminata T where T.Habilitado=1
END 