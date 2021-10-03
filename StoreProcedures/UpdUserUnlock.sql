CREATE PROCEDURE dbo.DesbloquearUsuario (@nUsuario            INT) AS

    IF ISNULL(@nUsuario, 0) > 0
        UPDATE dbo.Usuarios SET Intentos = 0,
                             Bloqueado    = 0
         WHERE Id_Usuario    = @nUsuario
    

GO