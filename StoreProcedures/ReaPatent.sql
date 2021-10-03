CREATE PROCEDURE dbo.ObtenerPatente (@nPatente		INT) AS

	
	SELECT P.Id_Patente,	P.Descripcion,	P.Desc_Corta, P.Fecha_Sys
	  FROM dbo.Patente p (NOLOCK)
	 WHERE P.Id_Patente = @nPatente
	 
GO