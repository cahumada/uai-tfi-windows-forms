CREATE PROCEDURE dbo.ObtenerIdiomas AS

     SELECT i.Id_Idioma, i.Descripcion, i.Desc_Corta, i.Fecha_Sys
      FROM dbo.Idioma i (NOLOCK)

GO