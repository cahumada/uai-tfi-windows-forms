CREATE PROCEDURE dbo.ActualizarPatente (@nPatente		INT,
                    								@sDescripcion		VARCHAR(30),
                    								@sDesc_Corta	VARCHAR(12)) AS

	
	UPDATE dbo.Patente 
	   SET Descripcion   = @sDescripcion,
	       Desc_Corta = @sDesc_Corta
	 WHERE Id_Patente     = @nPatente
	  
GO