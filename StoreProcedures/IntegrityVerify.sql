ALTER PROCEDURE dbo.VerificarIntegridad AS
    
    DECLARE @sNombreTabla   VARCHAR(50),  
            @nDVH           INT,
            @sSQL           VARCHAR(MAX),
            @nCriticidad   INT,
            @nTipoMovimiento  INT,
            @dFechaMov    DATETIME
            
    CREATE TABLE #TMP_Integridad (sNombreTabla VARCHAR(50))
    
    DECLARE c_DVV CURSOR LOCAL FOR
        SELECT Nombre_Tabla,  NDVH
          FROM dbo.DVV (NOLOCK)
    FOR READ ONLY
    
    OPEN c_DVV
    
    FETCH NEXT FROM c_DVV INTO @sNombreTabla, @nDVH
    
    WHILE @@FETCH_STATUS = 0
    BEGIN

       SELECT @sSQL = 'DECLARE @nDVV_Aux   INT ' +

               'SELECT @nDVV_Aux = CHECKSUM_AGG(NDVH) ' + 
               '  FROM dbo.' + RTRIM(@sNombreTabla) + ' (NOLOCK) ' +
               
               'IF @nDVV_Aux <> ' + CONVERT(VARCHAR,@nDVH) + 
               'BEGIN ' +
               '    INSERT INTO #TMP_Integridad (sTableName) ' +
               '                        VALUES (''' + RTRIM(@sNombreTabla) + ''')' +
               'END ' 

        --select @sSQL        
        EXECUTE (@sSQL)
    
        FETCH NEXT FROM c_DVV INTO @sNombreTabla, @nDVH
    END
    
    CLOSE c_DVV
    DEALLOCATE c_DVV
    
    IF EXISTS(SELECT 1  
                FROM #TMP_Integridad)
    BEGIN
        SELECT @nCriticidad  = 1,
               @nTipoMovimiento = Id_Movimiento,
               @dFechaMov   = CONVERT(DATETIME, GETDATE(), 112)
          FROM dbo.Tipo_Movimiento (NOLOCK)
         WHERE Id_Movimiento  = 1 --Integridad DV
        
        EXEC dbo.AddBitacora @nLog          = NULL,
                             @nUser         = NULL,
                             @nCriticidad  = @nCriticidad,
                             @nTipoMovimiento = @nTipoMovimiento,
                             @dEffectDate   = @dFechaMov
        
        SELECT 1
                                  
    END
    ELSE
      SELECT 2
  
    DROP TABLE #TMP_Integridad  
GO