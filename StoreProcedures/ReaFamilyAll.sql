CREATE PROCEDURE dbo.ObtenerFamilias AS

	
		SELECT f.Id_Familia,	f.Descripcion,	f.Desc_Corta, f.Fecha_Sys
	  FROM dbo.Familia f (NOLOCK)
	  
GO