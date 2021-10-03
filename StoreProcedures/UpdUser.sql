CREATE PROCEDURE dbo.ActualizarUsuario (@nUsuario            INT,
                              @sNik             VARCHAR(16),
                              @sContrasena        VARCHAR(264),
                              @nIdioma        INT,
                              @nIntentos   SMALLINT,
                              @bAdmin      BIT,
                              @bBloqueado      BIT) AS

    IF ISNULL(@nUsuario,0) > 0
        UPDATE dbo.Usuarios SET Id_Idioma      = @nIdioma,
                             Nik           = @sNik,
                             Contrasena      = @sContrasena,
                             Intentos = @nIntentos,
                             Bloqueado    = @bBloqueado,
                             Admin    = @bAdmin,
                             DVH           = BINARY_CHECKSUM(@nUsuario,@sNik, @sContrasena)
         WHERE Id_Usuario = @nUsuario
             
                                
GO
