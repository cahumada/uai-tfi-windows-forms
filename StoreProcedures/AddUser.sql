CREATE PROCEDURE dbo.AgregarUser (@nUsuario            INT,
                              @sNik             VARCHAR(16),
                              @sContrasena        VARCHAR(264),
                              @nIdioma        INT,
                              @nIntentos   SMALLINT,
                              @bAdmin      BIT,
                              @bBloqueado      BIT) AS

    IF ISNULL(@nUsuario,0) = 0
    BEGIN
        SELECT @nUsuario = ISNULL(MAX(ISNULL(Id_Usuario,0)),0)
            FROM dbo.Usuarios (NOLOCK)

        SET @nUsuario += 1
    END 

    SET @nIntentos = ISNULL(@nIntentos,0)
     
    INSERT INTO dbo.Usuarios (Id_Usuario,
                           Id_Idioma,
                           Nik,
                           Contrasena,
                           Intentos,
                           Bloqueado,
                           DVH,
                           Admin)
                   VALUES (@nUsuario,
                           @nIdioma,
                           @sNik,
                           @sContrasena,
                           @nIntentos,
                           @bBloqueado,
                           BINARY_CHECKSUM(@nUsuario,@sNik, @sContrasena),
                           @bAdmin)
         
                            
GO