CREATE PROCEDURE dbo.ObtenerUsuarioPatente (@nUsuario      INT) AS
    
    SELECT P.Id_Patente,    P.Descripcion,  P.Desc_Corta,
           P.Fecha_Sys,     U.Id_Usuario,         U.Nik,         
           U.Contrasena,     U.Id_Idioma,    U.Intentos,
           U.Bloqueado,      UP.DVH,   UP.Id_UsuarioPatente
      FROM dbo.Usuario_Patente UP (NOLOCK)
      JOIN dbo.Usuarios U (NOLOCK)
        ON U.Id_Usuario   = UP.Id_Usuario
      JOIN dbo.Patente P (NOLOCK)
        ON P.Id_Patente = UP.Id_Patente
     WHERE UP.Id_Usuario  = @nUsuario
     UNION
    SELECT P.Id_Patente,       P.Descripcion,    P.Desc_Corta,
           P.Fecha_Sys,     U.Id_Usuario,         U.Nik,
           U.Contrasena,     U.Id_Idioma,    U.Intentos,
           U.Bloqueado,   UF.DVH,     UF.Id_UsuarioFamilia
      FROM dbo.Familia_Patente FP (NOLOCK)
      JOIN dbo.Usuario_Familia UF
        ON UF.Id_Familia = FP.Id_Familia
      JOIN dbo.Usuarios U (NOLOCK)
        ON U.Id_Usuario   = UF.Id_Usuario
      JOIN dbo.Patente P (NOLOCK)
        ON P.Id_Patente = FP.Id_Patente
     WHERE U.Id_Usuario   = @nUsuario
              
GO