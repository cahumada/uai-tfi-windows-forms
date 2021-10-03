CREATE PROCEDURE dbo.ObtenerUsuarioNik (@sNik   VARCHAR(16)) AS

    SELECT Id_Usuario,  Id_Idioma,      Nik,
           Contrasena,  Intentos,       Bloqueado,
           DVH,         Admin
      FROM dbo.Usuarios (NOLOCK)
     WHERE UPPER(RTRIM(Nik)) = UPPER(RTRIM(@sNik))

GO
