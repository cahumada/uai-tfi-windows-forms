CREATE PROCEDURE dbo.ObtenerUsuarioPatentes AS
    
    SELECT P.Id_Patente,    P.Descripcion,  P.Desc_Corta,
           P.Fecha_Sys,     U.Id_Usuario,         U.Nik,         
           U.Contrasena,     U.Id_Idioma,    U.Intentos,
           U.Bloqueado,      UP.DVH,   UP.Id_UsuarioPatente
      FROM dbo.Usuario_Patente UP (NOLOCK)
      JOIN dbo.Usuarios U (NOLOCK)
        ON U.Id_Usuario   = UP.Id_Usuario
      JOIN dbo.Patente P (NOLOCK)
        ON P.Id_Patente = UP.Id_Patente
              
GO