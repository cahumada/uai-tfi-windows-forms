CREATE PROCEDURE dbo.ObtenerIdiomaUsuario (@nUsuario INT = NULL) AS

    IF @nUsuario IS NULL
    BEGIN
        SELECT Id_Idioma, Descripcion, Fecha_Sys, Desc_Corta
          FROM dbo.Idioma (NOLOCK)
         WHERE Id_Idioma = 1
    END
    ELSE
    BEGIN
        SELECT I.Id_Idioma, I.Descripcion, I.Fecha_Sys, I.Desc_Corta
          FROM dbo.Usuarios U (NOLOCK)
          JOIN dbo.Idioma I (NOLOCK)
            ON U.Id_Idioma = I.Id_Idioma
         WHERE U.Id_Usuario     = @nUsuario
    END

GO
