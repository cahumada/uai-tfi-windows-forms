CREATE PROCEDURE dbo.EliminarUsuarioFamilia (@nUsuarioFamiliaId    BIGINT) AS
  
  DELETE dbo.Usuario_Familia 
   WHERE Id_UsuarioFamilia = @nUsuarioFamiliaId
                                    
GO