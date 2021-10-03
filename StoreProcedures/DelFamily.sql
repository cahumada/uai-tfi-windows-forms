CREATE PROCEDURE dbo.EliminarFamilia (@nFamilia		INT) AS

	
	DELETE dbo.Familia 
	 WHERE Id_Familia = @nFamilia
	 
GO