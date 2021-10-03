CREATE PROCEDURE dbo.AgregarFamilia (@nFamilia		INT,
                    								@sDescripcion		VARCHAR(30),
                    								@sDesc_Corta	VARCHAR(12)) AS

	
	IF ISNULL(@nFamilia, 0) = 0
		SELECT @nFamilia = ISNULL(MAX(ISNULL(f.Id_Familia,0)),0) + 1
		  FROM dbo.Familia f (NOLOCK)
	  
	INSERT INTO dbo.Familia (Id_Familia,	Descripcion,	Desc_Corta, Fecha_Sys)
					VALUES (@nFamilia,	@sDescripcion, @sDesc_Corta, getdate())
	 
GO