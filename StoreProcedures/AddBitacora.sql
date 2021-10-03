CREATE PROCEDURE dbo.AgregarBitacora (@nLog             BIGINT = NULL,
                                  @nUsuario         INT = NULL,
                                  @nCriticidad      INT,
                                  @nTipoMovimiento  INT,
                                  @FechaMovimiento  DATETIME) AS
                                
    IF ISNULL(@nLog,0) = 0
    BEGIN
        SELECT @nLog = ISNULL(MAX(ISNULL(Id_Log,0)),0)
          FROM dbo.Bitacora (NOLOCK)
          
        SELECT @nLog = ISNULL(@nLog,0) + 1
    END 
    
    SELECT @nUsuario = ISNULL(@nUsuario,999)
    
    SELECT @FechaMovimiento = CONVERT(DATETIME, @FechaMovimiento, 112)
    
    INSERT INTO dbo.Bitacora (Id_Log,
                              Id_Usuario,
                              Id_Movimiento,
                              Id_Criticidad,
                              Fecha_Movimiento,
                              DVH)
                      VALUES (@nLog,
                              @nUsuario,
                              @nCriticidad,
                              @nTipoMovimiento,
                              @FechaMovimiento,
                              BINARY_CHECKSUM(@nLog,@nUsuario,@FechaMovimiento,@nCriticidad,@nTipoMovimiento))
                                  
GO
                                  