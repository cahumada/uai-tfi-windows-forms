CREATE PROCEDURE dbo.ObtenerUsuario (@nUsuario            INT) AS

  SELECT Id_Usuario,  Id_Idioma,      Nik,
           Contrasena,  Intentos,       Bloqueado,
           DVH,         Admin
      FROM dbo.Usuarios (NOLOCK)
     WHERE Id_Usuario = @nUsuario

GO