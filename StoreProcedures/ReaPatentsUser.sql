CREATE PROCEDURE dbo.ObtenerPatenteUsuario (@nUsuario     INT) AS

    SELECT P.Id_Patente,   P.Descripcion,    P.Desc_Corta, 
           p.Fecha_Sys
      FROM dbo.Usuario_Familia US (NOLOCK)
      JOIN dbo.Familia_Patente FP (NOLOCK)
        ON US.Id_Familia = FP.Id_Familia
      JOIN dbo.Patente P (NOLOCK)
        ON P.Id_Patente  = FP.Id_Patente
      LEFT JOIN dbo.Usuario_Patente UP (NOLOCK)
        ON US.Id_Usuario   = UP.Id_Usuario
     WHERE US.Id_Usuario   = @nUsuario

GO