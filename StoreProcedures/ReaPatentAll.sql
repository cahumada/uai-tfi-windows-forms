CREATE PROCEDURE dbo.ObtenerPatentes AS

	
	SELECT P.Id_Patente,	P.Descripcion,	P.Desc_Corta, P.Fecha_Sys
	  FROM dbo.Patente p (NOLOCK)
	 
GO