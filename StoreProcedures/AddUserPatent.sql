CREATE PROCEDURE dbo.AgregarUsuarioPatente (@nUsuario      INT,
                                    @nPatente    INT,
                                    @bDenegar    BIT = NULL) AS
    
    INSERT INTO dbo.Usuario_Patente (Id_Usuario,
                                 Id_Patente,
                                 DVH)
                         VALUES (@nUsuario,
                                 @nPatente,
                                 BINARY_CHECKSUM(@nUsuario, @nPatente))
                                      
GO