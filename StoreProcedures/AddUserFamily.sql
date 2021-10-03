CREATE PROCEDURE dbo.AltaUsuarioFamilia (@nFamilia    INT,
                                    @nUsuario      INT) AS
  
  INSERT INTO dbo.Usuario_Familia (Id_Usuario,
                               Id_Familia,
                               DVH)
                       VALUES (@nUsuario,
                               @nFamilia,
                               BINARY_CHECKSUM(@nUsuario, @nFamilia))
                                    
GO