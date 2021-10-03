CREATE PROCEDURE dbo.ObtenerUsuarioFamilias AS
  
  SELECT F.Id_Familia,     F.Descripcion,    F.Desc_Corta,
           f.Fecha_Sys,      U.Id_Usuario,       U.Nik,         
           U.Contrasena,   U.Id_Idioma,    U.Intentos,
           U.Bloqueado, UF.DVH, UF.Id_UsuarioFamilia
      FROM dbo.Usuario_Familia  UF (NOLOCK)
      JOIN dbo.Usuarios U (NOLOCK)
        ON U.Id_Usuario    = UF.Id_Usuario
      JOIN dbo.Familia F (NOLOCK)
        ON F.Id_Familia  = UF.Id_Familia

                                    
GO