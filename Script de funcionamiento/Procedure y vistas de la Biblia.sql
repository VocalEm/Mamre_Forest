DROP PROCEDURE spbiblia

CREATE PROCEDURE spbiblia
(
	@Opcion TINYINT,
	@Idioma INT,
--FAVORITOS
	@Version VARCHAR(50),
	@Libro VARCHAR(50),
	@Capitulo TINYINT,
	@Versiculo TINYINT,

--HISTORIAL
	@palabras VARCHAR(100),
	@Testamento VARCHAR(50)
)
AS 
BEGIN

	DECLARE @palabra NVARCHAR(255)
	DECLARE @consulta NVARCHAR(MAX)

	--OPCION 1 CONSULTAS
	IF(@Opcion = 1)
		BEGIN
		SELECT Cita, Pasaje FROM ConsultarVersiculos(@Libro,@Capitulo,@Versiculo,@Version);
	END;

	--busqueda
	IF @Opcion = 2
	BEGIN
		IF(@Testamento IS NULL AND @Libro IS NULL)
		BEGIN
		 SET @consulta = N'SELECT CONCAT(Libro, '' '', [C-V]) AS Cita, Texto AS Pasaje FROM Busquedas WHERE [Version] = @VersionParam AND '
        -- Elimina los espacios adicionales y la primera coma de la cadena de entrada
        SET @palabras = REPLACE(@palabras, ' ', '')
        IF RIGHT(@palabras, 1) = ','
        SET @palabras = LEFT(@palabras, LEN(@palabras) - 1)
        IF LEFT(@palabras, 1) = ','
        SET @palabras = RIGHT(@palabras, LEN(@palabras) - 1)

        -- Divide la cadena de entrada en palabras individuales
        DECLARE palabras_cursor CURSOR FOR
        SELECT value FROM STRING_SPLIT(@palabras, ',')

        OPEN palabras_cursor
        FETCH NEXT FROM palabras_cursor INTO @palabra

        WHILE @@FETCH_STATUS = 0
        BEGIN
        -- Agrega una cláusula LIKE para cada palabra
        SET @consulta = @consulta + ' ([Version] =  @VersionParam  AND (Texto LIKE ''%' + @palabra + '%'')) AND'

        FETCH NEXT FROM palabras_cursor INTO @palabra
        END

        CLOSE palabras_cursor
        DEALLOCATE palabras_cursor

        -- Elimina el último 'OR'
        SET @consulta = LEFT(@consulta, LEN(@consulta) - 3)

        -- Ejecuta la consulta
        EXEC sp_executesql @consulta, N'@VersionParam NVARCHAR(50)', @VersionParam = @Version
		END

		IF(@Testamento IS NOT NULL AND @Libro IS NULL)
		BEGIN
			SET @consulta = N'SELECT CONCAT(Libro, '' '', [C-V]) AS Cita, Texto AS Pasaje FROM Busquedas WHERE Version = @VersionParam AND Testamento = @TestamentoParam AND '
			-- Elimina los espacios adicionales y la primera coma de la cadena de entrada
			SET @palabras = REPLACE(@palabras, ' ', '')
			IF RIGHT(@palabras, 1) = ','
			SET @palabras = LEFT(@palabras, LEN(@palabras) - 1)
			IF LEFT(@palabras, 1) = ','
			SET @palabras = RIGHT(@palabras, LEN(@palabras) - 1)

			-- Divide la cadena de entrada en palabras individuales
			DECLARE palabras_cursor CURSOR FOR
			SELECT value FROM STRING_SPLIT(@palabras, ',')

			OPEN palabras_cursor
			FETCH NEXT FROM palabras_cursor INTO @palabra

			WHILE @@FETCH_STATUS = 0
			BEGIN
			-- Agrega una cláusula LIKE para cada palabra
			SET @consulta = @consulta + ' (Testamento =  @TestamentoParam  AND (Texto LIKE ''%' + @palabra + '%'')) AND'

			FETCH NEXT FROM palabras_cursor INTO @palabra
			END

			CLOSE palabras_cursor
			DEALLOCATE palabras_cursor

			-- Elimina el último 'OR'
			SET @consulta = LEFT(@consulta, LEN(@consulta) - 3)

			-- Ejecuta la consulta
			EXEC sp_executesql @consulta, N'@VersionParam NVARCHAR(50), @TestamentoParam NVARCHAR(50)', @VersionParam = @Version, @TestamentoParam = @Testamento
		END

		IF(@Testamento IS NOT NULL AND @Libro IS NOT NULL)
		BEGIN
			SET @consulta = N'SELECT CONCAT(Libro, '' '', [C-V]) AS Cita, Texto AS Pasaje FROM Busquedas WHERE Version = @VersionParam AND Testamento = @TestamentoParam AND Libro = @LibroParam AND '
			-- Elimina los espacios adicionales y la primera coma de la cadena de entrada
			SET @palabras = REPLACE(@palabras, ' ', '')
			IF RIGHT(@palabras, 1) = ','
			SET @palabras = LEFT(@palabras, LEN(@palabras) - 1)
			IF LEFT(@palabras, 1) = ','
			SET @palabras = RIGHT(@palabras, LEN(@palabras) - 1)
			
			-- Divide la cadena de entrada en palabras individuales
			DECLARE palabras_cursor CURSOR FOR
			SELECT value FROM STRING_SPLIT(@palabras, ',')
			
			OPEN palabras_cursor
			FETCH NEXT FROM palabras_cursor INTO @palabra
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			-- Agrega una cláusula LIKE para cada palabra
			SET @consulta = @consulta + ' (Testamento =  @TestamentoParam  AND  Libro = @LibroParam AND (Texto LIKE ''%' + @palabra + '%'')) AND'
			
			FETCH NEXT FROM palabras_cursor INTO @palabra
			END
			
			CLOSE palabras_cursor
			DEALLOCATE palabras_cursor
			
			-- Elimina el último 'OR'
			SET @consulta = LEFT(@consulta, LEN(@consulta) - 3)
			
			-- Ejecuta la consulta
			EXEC sp_executesql @consulta, N'@VersionParam NVARCHAR(50), @TestamentoParam NVARCHAR(50), @LibroParam NVARCHAR(50)', @VersionParam = @Version, @TestamentoParam = @Testamento, @LibroParam = @Libro
		END
	END;

	--Mandar Libros 
	IF @Opcion = 3
	BEGIN
		SET @consulta = DB_Bible.dbo.MandarInformacion(1);
		EXECUTE(@consulta);
	END;

	--Mandar Versiones
	IF @Opcion = 4
	BEGIN
		SET @consulta = DB_Bible.dbo.MandarInformacion(2);
		EXECUTE(@consulta);
	END;
	
	--Mandar CapsTotales
	IF @Opcion = 5
	BEGIN
		SET @consulta = DB_Bible.dbo.MandarInformacion(3);
		EXECUTE(@consulta);
	END;

	--Mandar Testamentos
	IF @Opcion = 6
	BEGIN
		SET @consulta = DB_Bible.dbo.MandarInformacion(4);
		EXECUTE(@consulta);
	END;
END;

--VISTAS
DROP VIEW consultas
CREATE VIEW consultas
AS SELECT CONCAT(L.Nombre ,' ' , V.NumeroCap , ':' , V.NumeroVers) AS Cita,
V.Texto AS Pasaje , VE.NombreVersion AS [Version] FROM Libros L JOIN Versiculos V ON L.Id_Libro = V.Id_Libro JOIN Versiones VE ON V.Id_Version = VE.Id_Version;

DROP VIEW Busquedas
CREATE VIEW Busquedas
AS SELECT VE.NombreVersion AS [Version], T.Nombre AS Testamento, L.Nombre AS Libro , CONCAT(V.NumeroCap,':',V.NumeroVers) AS [C-V], V.Texto AS Texto
				FROM Versiculos V JOIN Versiones VE ON V.Id_Version = VE.Id_Version
				JOIN Libros L ON V.Id_Libro = L.Id_Libro
				JOIN Testamentos T ON L.Id_Testamento = T.Id_Testamento;

--Funciones
DROP FUNCTION ConsultarVersiculos
CREATE FUNCTION ConsultarVersiculos
(
    @Libro NVARCHAR(50),
    @Capitulo INT,
    @Versiculo INT,
    @Version NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
WITH consulta AS (
    SELECT Cita, Pasaje
    FROM consultas
    WHERE [Version] = @Version
    AND Cita LIKE @Libro + ' ' + CAST(@Capitulo AS VARCHAR) + 
    CASE 
        WHEN @Versiculo IS NULL THEN ':%'
        ELSE ':' + CAST(@Versiculo AS VARCHAR)
    END
)
SELECT * FROM consulta;

DROP FUNCTION MandarInformacion
CREATE FUNCTION MandarInformacion
(
    @Opcion TINYINT
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @consulta NVARCHAR(MAX);

    IF @Opcion = 1
        SET @consulta = 'SELECT Nombre FROM Libros';
    ELSE IF @Opcion = 2
        SET @consulta = 'SELECT NombreVersion FROM Versiones';
    ELSE IF @Opcion = 3
        SET @consulta = 'SELECT CapitulosTot FROM Libros';
    ELSE IF @Opcion = 4
        SET @consulta = 'SELECT Nombre FROM Testamentos';
    ELSE
        SET @consulta = 'SELECT NULL';
    RETURN @consulta;
END;

SELECT * FROM consultas
SELECT*FROM Busquedas
SELECT * FROM Versiculos

UPDATE Versiculos SET Id_Libro = 67 WHERE  Id_Version = 4 AND Id_Libro = 1;
UPDATE Versiculos SET Id_Libro = 72 WHERE  Id_Version = 4 AND Id_Libro = 6;


SELECT CONCAT(Libro, ' ', [C-V]) AS Cita, Texto FROM Busquedas