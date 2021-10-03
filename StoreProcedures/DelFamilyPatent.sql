CREATE PROCEDURE dbo.EliminarFamiliaPatente (@nFamilyPatentId		BIGINT) AS
	                   
	DELETE dbo.Familia_Patente
	 WHERE Id_FamiliaPatente = @nFamilyPatentId
	 
GO