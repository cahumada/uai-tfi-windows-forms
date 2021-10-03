CREATE PROCEDURE dbo.ObtenerMenu AS

    SELECT Id,         Descripcion,      HijoDe,
           NombreForm,   FamiliaId,        PatenteId
      FROM dbo.MyMenu (NOLOCK)

GO

