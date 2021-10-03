CREATE PROCEDURE dbo.ActualizarContrasena (@nUsuario            INT,
                                      @sContrasena     VARCHAR(264)) AS

    IF ISNULL(@nUsuario, 0) > 0
        UPDATE dbo.Usuarios SET Contrasena      = @sContrasena,
                             Intentos = 0,
                             Bloqueado    = 0
         WHERE Id_Usuario    = @nUsuario
                                    
GO