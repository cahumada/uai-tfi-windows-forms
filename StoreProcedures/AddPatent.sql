CREATE PROCEDURE dbo.AgregarPatente (@nPatente		INT,
                    								@sDescripcion		VARCHAR(30),
                    								@sDesc_Corta	VARCHAR(12)) AS

	
	IF ISNULL(@nPatente,0) = 0
		SELECT @nPatente = ISNULL(MAX(ISNULL(p.Id_Patente,0)),0) + 1
		  FROM dbo.Patente p (NOLOCK)
	  
	INSERT INTO dbo.Patente (Id_Patente,	Descripcion,	Desc_Corta, Fecha_Sys)
					VALUES (@nPatente,	@sDescripcion, @sDesc_Corta, getdate())
	 
GO