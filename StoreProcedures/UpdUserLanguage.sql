CREATE PROCEDURE dbo.ActualizarUsuarioIdioma (@nUsuario            INT,
                                      @Idioma        INT) AS

    IF ISNULL(@nUsuario, 0) > 0
        UPDATE dbo.Usuarios SET Id_Idioma      = @Idioma
         WHERE Id_Usuario    = @nUsuario
                                    
GO