CREATE PROCEDURE dbo.ObtenerFamilia (@nFamilia		INT) AS

	
	SELECT f.Id_Familia,	f.Descripcion,	f.Desc_Corta, f.Fecha_Sys
	  FROM dbo.Familia f (NOLOCK)
	 WHERE f.Id_Familia = @nFamilia
	  
GO