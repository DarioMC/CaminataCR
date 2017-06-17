USE [Caminata]
GO

/****** Object:  StoredProcedure [dbo].[SPS_CrearCaminataXHiker]    Script Date: 16/6/2017 17:17:13: PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPS_CrearCaminataXHiker](
@caminata int, @hiker int
)
AS 
BEGIN
Insert into CaminataXHiker
Values(@caminata, @hiker)
END
GO

