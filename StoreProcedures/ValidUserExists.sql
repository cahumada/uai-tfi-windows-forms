CREATE PROCEDURE dbo.ValidarUsuarioExistente  @nUsuario  INT AS

    DECLARE @nExiste INT

    IF EXISTS(SELECT 1
                FROM dbo.Usuarios u (NOLOCK)
               WHERE u.Id_Usuario = @nUsuario)
        SET @nExiste = 1
    ELSE
        SET @nExiste = 0

    SELECT @nExiste
GO