CREATE PROCEDURE dbo.EliminarUsuarioPatente (@nUsuarioPatenteId      BIGINT) AS
    
    DELETE dbo.Usuario_Patente 
     WHERE Id_UsuarioPatente   = @nUsuarioPatenteId
              
GO