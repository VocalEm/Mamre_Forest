DROP PROCEDURE spUsuarios
CREATE PROCEDURE spUsuarios
(
--Datos del usuario para Insert
	@opcion TINYINT,
	@nombre VARCHAR(50),
	@ApPat VARCHAR(50),
	@ApMat VARCHAR(50),
	@FechaNacimiento DATE,
	@Genero BIT,
	@Correo VARCHAR(50),
	@Contrase�a VARCHAR(50),
	@Contrase�aNueva VARCHAR(50),
	@CodigoRec SMALLINT,
	@Estatus BIT,
	@Tama�oLetra INT,	
	@IdiomaPref INT,

	--PARA ENCONTRAR USUARIO ESPECIFICO
	@ID INT,
	--output
	@UsuarioError BIT OUTPUT,
	@nombreOutput VARCHAR(50) OUTPUT,
	@ApPatOutput VARCHAR(50) OUTPUT,
	@ApMatOutput VARCHAR(50) OUTPUT,
	@FechaNacimientoOutput DATE OUTPUT,
	@GeneroOutput BIT OUTPUT,
	@CorreoOutput VARCHAR(50) OUTPUT,
	@Tama�oLetraOutput INT OUTPUT,	
	@IdiomaPrefOutput INT OUTPUT,
	@FechaRegistroOutput SMALLDATETIME OUTPUT,

	@NumeroVersion SMALLINT,
	@NumeroLibro SMALLINT,
	@NumeroCapitulo TINYINT,
	@NumeroVersiculo TINYINT,

	@Palabras VARCHAR(100),
	@Testamento SMALLINT
)
AS
BEGIN

	--Usuario Error 1 indica que se mando un error, y  si es  0 significa que se ejecuto con exito
	DECLARE @Hoy SMALLDATETIME,
			@HoyBaja DATE,
			@ID_Contrase�a INT;

	SET @Hoy = CAST(GETDATE() AS SMALLDATETIME);
	SET @HoyBaja = CAST(GETDATE() AS DATE);

	--INSERT USUARIOS // VALIDANDO CORREO UNICO
	IF @opcion = 1
	BEGIN
		IF EXISTS(SELECT 1 FROM Usuario WHERE Correo = @Correo)
		BEGIN
			SET @UsuarioError = 1; --USUARIO SI EXISTE POR LO TANTO MANDAMOS UN ERROR PARA QUE NO SE INSERTE 
		END
		ELSE
		BEGIN
			SET @UsuarioError = 0;
			INSERT INTO Contrase�as (Contrase�aActual)VALUES (@Contrase�a);
			SET @ID_Contrase�a = SCOPE_IDENTITY();

			INSERT INTO Usuario (Nombre,ApPat,ApMat,FechaNacimiento,Genero,Correo,ID_Contrase�as,ID_IdiomaPreferido,Tama�oLetra,CodigoRec,Estatus,Fecha_HoraRegistro)
			VALUES				(@nombre,@ApPat,@ApMat,@FechaNacimiento,@Genero,@Correo,@ID_Contrase�a,1,15,@CodigoRec,1,@Hoy);
		END
		
	END;

	--BAJA LOGICA 
	IF @opcion = 2
	BEGIN
		IF EXISTS(SELECT 1 FROM vInicioSesion WHERE Correo = @Correo)
		BEGIN
			UPDATE Usuario
			SET Estatus = 0, FechaBaja = @HoyBaja
			WHERE Correo = @Correo;
			SET @UsuarioError = 0;
		END
		ELSE
		BEGIN
			SET @UsuarioError = 1;
		END
	END;

	--inicio sesion
	IF @opcion = 3
	BEGIN
		IF EXISTS(SELECT 1 FROM vInicioSesion WHERE Correo = @Correo AND Contrase�a = @Contrase�a COLLATE SQL_Latin1_General_CP1_CS_AS)
		BEGIN
			SET @UsuarioError = 0;
		END
		ELSE
		BEGIN
			SET @UsuarioError = 1;
		END
	END;

	--Actualizar Informacion COMPLETA
	IF @opcion = 4
	BEGIN
		SET @ID = MAD.dbo.ObtenerID(@Contrase�a);
		IF EXISTS(SELECT 1 FROM Contrase�as WHERE ID = @ID AND (@Contrase�aNueva = 'NO' OR (@Contrase�aNueva <> Contrase�aActual OR Contrase�aActual IS NULL)AND  (@Contrase�aNueva <> Contrase�aAnterior1 OR Contrase�aAnterior1 IS NULL) AND  (@Contrase�aNueva <> Contrase�aAnterior2 OR Contrase�aAnterior2 IS NULL)))
		BEGIN
			IF EXISTS(SELECT 1 FROM Usuario WHERE ID <> @ID AND Correo = @Correo)
			BEGIN
				SET @UsuarioError = 1;
			END
			ELSE
			BEGIN 
				IF(@Contrase�aNueva = 'NO')
				BEGIN
					UPDATE Usuario
					SET Nombre = @nombre, ApPat = @ApPat, ApMat = @ApMat, Correo = @Correo, Tama�oLetra = @Tama�oLetra, ID_IdiomaPreferido = @IdiomaPref, CodigoRec = @CodigoRec, Genero = @Genero
					WHERE ID = @ID;
					SET @UsuarioError = 0;
				END

				ELSE
				BEGIN
					UPDATE Usuario
					SET Nombre = @nombre, ApPat = @ApPat, ApMat = @ApMat, Correo = @Correo, Tama�oLetra = @Tama�oLetra, ID_IdiomaPreferido = @IdiomaPref, CodigoRec = @CodigoRec, Genero = @Genero
					WHERE ID = @ID;

					UPDATE Contrase�as
					SET Contrase�aAnterior2 = Contrase�aAnterior1, Contrase�aAnterior1 = Contrase�aActual, Contrase�aActual = @Contrase�aNueva
					WHERE ID = @ID;
					SET @UsuarioError = 0;

				END
			END
		END

		ELSE
		BEGIN
			SET @UsuarioError = 1;
		END
	END;

	--Recuperacion de cuenta
	IF @opcion = 5
	BEGIN
		--IF EXISTS(SELECT 1 FROM Usuario A JOIN Contrase�as B ON A.ID = B.ID WHERE A.Correo = @Correo AND A.CodigoRec = @CodigoRec AND (@Contrase�aNueva <> B.Contrase�aActual OR B.Contrase�aActual IS NULL)AND  (@Contrase�aNueva <> B.Contrase�aAnterior1 OR B.Contrase�aAnterior1 IS NULL) AND  (@Contrase�aNueva <> B.Contrase�aAnterior2 OR B.Contrase�aAnterior2 IS NULL)  AND Estatus = 0)
		IF EXISTS(SELECT 1 FROM vRecuperacion WHERE Correo = @Correo AND Codigo = @CodigoRec AND (@Contrase�aNueva <> Actual OR Actual IS NULL)AND  (@Contrase�aNueva <> Anterior1 OR Anterior1 IS NULL) AND  (@Contrase�aNueva <> Anterior2 OR Anterior2 IS NULL))
		BEGIN
			SET @ID = (SELECT ID FROM vRecuperacion WHERE Correo = @Correo);
			UPDATE Usuario
			SET Estatus = 1
			WHERE ID = @ID;

			UPDATE Contrase�as
			SET Contrase�aAnterior2 = Contrase�aAnterior1, Contrase�aAnterior1 = Contrase�aActual, Contrase�aActual = @Contrase�aNueva
			WHERE ID = @ID; 
			SET @UsuarioError = 0;
		END
		ELSE
		BEGIN
			SET @UsuarioError = 1;
		END	
	END;

	--Mostrar informacion en perfil
	IF @opcion = 6
	BEGIN 
		IF EXISTS(SELECT 1 FROM Usuario A JOIN Contrase�as B ON A.ID = B.ID WHERE A.Correo = @Correo AND B.Contrase�aActual = @Contrase�a)
		BEGIN
			SELECT @CorreoOutput = A.Correo, @nombreOutput = A.Nombre, @ApPatOutput = A.ApPat, 
			@ApMatOutput = A.ApMat, @FechaNacimientoOutput = A.FechaNacimiento,
			@FechaRegistroOutput = A.Fecha_HoraRegistro, @IdiomaPrefOutput = A.ID_IdiomaPreferido, @Tama�oLetraOutput = A.Tama�oLetra, @GeneroOutput = A.Genero
			FROM Usuario A JOIN Contrase�as B ON A.ID = B.ID WHERE A.Correo = @Correo AND B.Contrase�aActual = @Contrase�a;
			SET @UsuarioError = 0;

		END
		ELSE 
		BEGIN
			SET @UsuarioError = 1;
		END
	END;

	--Agregar FAVORITOS
	IF @Opcion = 7
	BEGIN
		SET @ID = MAD.dbo.ObtenerID(@Contrase�a);
		IF EXISTS(
    SELECT 1 
    FROM Favorito 
    WHERE ID_Usuario = @ID 
    AND Nombre = @nombre)
		BEGIN
			SET @UsuarioError = 1;
		END
		ELSE

		BEGIN
			INSERT INTO Favorito (Nombre,[Version],Libro,Capitulo,Versiculo,ID_Usuario,Hora_Fecha) VALUES (@nombre,@NumeroVersion,@NumeroLibro,@NumeroCapitulo,@NumeroVersiculo,@ID,@Hoy);
			SET @UsuarioError = 0;
		END
	END;

	--Mandar vista Favorito
	IF @Opcion = 8
	BEGIN
		SET @ID = MAD.dbo.ObtenerID(@Contrase�a);
		SELECT Nombre,Informacion FROM vFavorito WHERE ID_User = @ID;
	END;

	--DELETE FAVORITO
	IF @Opcion = 9
	BEGIN
		SET @ID = MAD.dbo.ObtenerID(@Contrase�a);
		IF EXISTS(SELECT 1 FROM Favorito WHERE ID_Usuario = @ID AND Nombre = @nombre)
		BEGIN
			DELETE FROM Favorito WHERE ID_Usuario = @ID AND Nombre = @nombre;
			SET @UsuarioError = 0;
		END
		ELSE
		BEGIN
			SET @UsuarioError = 1;
		END
	END;

	--AGREGAR HISTORIAL
	IF @Opcion = 10
	BEGIN
		SET @ID = MAD.dbo.ObtenerID(@Contrase�a);
		INSERT INTO Historial (Palabras, [Version], Testamento, Libro, ID_Usuario, Hora_Fecha) VALUES(@Palabras, @NumeroVersion, @Testamento,@NumeroLibro,@ID,@Hoy);
		SET @UsuarioError = 0;
	END;

	--Mandar Historial
	IF @Opcion = 11
	BEGIN
		SET @ID = MAD.dbo.ObtenerID(@Contrase�a);
		SELECT Fecha, Informacion, Palabras, ID FROM vHistorial WHERE ID_User = @ID;
	END;

	--Eliminar historial Completo
	IF @Opcion = 12
	BEGIN
	SET @ID = MAD.dbo.ObtenerID(@Contrase�a);
		IF EXISTS(SELECT 1 FROM Historial WHERE ID_Usuario = @ID)
		BEGIN
			DELETE FROM Historial WHERE ID_Usuario = @ID;
			SET @UsuarioError = 0;
		END
		ELSE
		BEGIN
			SET @UsuarioError = 1;
		END
	END;

	--eliminar busqueda
	IF @Opcion = 13
	BEGIN
		IF EXISTS(SELECT 1 FROM Historial WHERE ID = @ID)
		BEGIN
			DELETE FROM Historial WHERE ID = @ID;
			SET @UsuarioError = 0;
		END
		ELSE
		BEGIN
			SET @UsuarioError = 1;
		END
	END;

END;

--VISTAS
DROP VIEW vFavorito
CREATE VIEW vFavorito AS
SELECT 
    Nombre AS Nombre,
	CONCAT([Version] ,' ',Libro,' ',Capitulo,':',Versiculo,' ',Hora_Fecha) AS Informacion,
	ID_Usuario AS ID_User
FROM Favorito 

DROP VIEW vHistorial
CREATE VIEW vHistorial AS
SELECT 
	Hora_Fecha AS Fecha,
	CONCAT([Version],' ',
	CASE
	WHEN Testamento IS NULL THEN ''
	ELSE CAST(Testamento AS VARCHAR)
	END,
	' ',
	CASE
	WHEN Testamento IS NULL AND Libro IS NULL THEN 'TODA LA BIBLIA'
	WHEN Libro IS NULL THEN 'SOLO TESTAMENTO'
	ELSE CAST(Libro AS VARCHAR)
	END
	) AS Informacion,
	Palabras AS Palabras,
	ID_Usuario AS ID_User,
	ID AS ID
	FROM Historial;

DROP VIEW vInicioSesion
CREATE VIEW vInicioSesion
AS
SELECT U.Correo, C.Contrase�aActual AS Contrase�a FROM Usuario U JOIN Contrase�as C ON U.ID = C.ID WHERE U.Estatus = 1;

DROP VIEW vRecuperacion
CREATE VIEW vRecuperacion
AS
SELECT U.ID,U.Correo,U.CodigoRec AS Codigo, C.Contrase�aActual AS Actual ,C.Contrase�aAnterior1 AS Anterior1,C.Contrase�aAnterior2 AS Anterior2 FROM Usuario U JOIN Contrase�as C ON U.ID = C.ID WHERE U.Estatus = 0;

--FUNCTION
DROP FUNCTION ObtenerID
CREATE FUNCTION ObtenerID
(
    @Correo NVARCHAR(MAX)
)
RETURNS INT
AS
BEGIN
    DECLARE @ID INT;
    SET @ID = (SELECT ID FROM Usuario WHERE Correo = @Correo);
    RETURN @ID;
END;
