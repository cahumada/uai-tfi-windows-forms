CREATE PROCEDURE dbo.ActualizarFamilia (@nFamilia		INT,
                    								@sDescripcion		VARCHAR(30),
                    								@sDesc_Corta	VARCHAR(12)) AS

	
	UPDATE dbo.Familia 
	   SET Descripcion   = @sDescripcion,
           Desc_Corta = @sDesc_Corta,
        Fecha_Sys = getdate()
     WHERE Id_Familia     = @nFamilia
		 
GO