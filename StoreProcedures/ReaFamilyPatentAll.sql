CREATE PROCEDURE dbo.ObtenerFamiliaPatentes AS

	SELECT FP.Id_FamiliaPatente,
         FP.DVH,
         FP.Id_Patente,  
	       P.Descripcion 'Descripcion_P',    
	       P.Desc_Corta 'Desc_Corta_P',
         p.Fecha_Sys 'Fecha_Sys_P',
         FP.Id_Familia,
         P.Descripcion 'Descripcion_F',    
	       P.Desc_Corta 'Desc_Corta_F',
         p.Fecha_Sys 'Fecha_Sys_F'
	  FROM dbo.Familia_Patente FP (NOLOCK)
	  JOIN dbo.Patente P (NOLOCK)
	    ON FP.Id_Patente  = P.Id_Patente
	 
GO