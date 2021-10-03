CREATE PROCEDURE dbo.ObtenerIdioma @nIdioma INT AS

    SELECT i.Id_Idioma, i.Descripcion, i.Desc_Corta, i.Fecha_Sys
      FROM dbo.Idioma i (NOLOCK)
     WHERE i.Id_Idioma = @nIdioma

GO