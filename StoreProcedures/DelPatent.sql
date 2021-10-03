CREATE PROCEDURE dbo.EliminarPatente (@nPatente		INT) AS

	
	DELETE dbo.Patente
	 WHERE Id_Patente = @nPatente 
	 
GO