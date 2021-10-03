CREATE PROCEDURE dbo.AgregarFamiliaPatente (@nFamilia		INT,
                                      @nPatente		INT) AS

	
	INSERT INTO dbo.Familia_Patente (Id_Familia,     
	                               Id_Patente,    
	                               DVH)
	                       VALUES (@nFamilia,    
	                               @nPatente,   
	                               BINARY_CHECKSUM(@nFamilia,@nPatente))
	 
GO