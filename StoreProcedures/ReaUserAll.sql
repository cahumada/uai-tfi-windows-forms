CREATE PROCEDURE dbo.ObtenerUsuarios AS

   SELECT Id_Usuario,  Id_Idioma,      Nik,
           Contrasena,  Intentos,       Bloqueado,
           DVH,         Admin
      FROM dbo.Usuarios (NOLOCK)

GO