CREATE DATABASE DB_Bible;
--CREATE DATABASE DB_Proy;

/*
Script para la creación de las tablas de la Biblia
Autor: Alejandro Villarreal
Fecha: 19-Marzo-2023
MAD 
Ene-Jun 2024
LMAD

*/

-- Confirmar que la BD: DB_Bible
-- ya esté creada antes de ejecutar este script

-- este script lo pueden ejecutar las veces que sean necesarias, 
-- para eliminar y crear las tablas de nuevo

/*
PROYECTO MAD
Ene-Jun 2024
*/


USE DB_Bible;

/*
Modelo Relacional

Diseño Lógico

Idiomas (Id_Idioma PK, Nombre)


Versiones (Id_Version PK, NombreVersion, 
Traductor, Año, Id_Idioma FK)

*/
IF OBJECT_ID('Versiculos') IS NOT NULL
	DROP TABLE Versiculos;
IF OBJECT_ID('Capitulos') IS NOT NULL
	DROP TABLE Capitulos;
IF OBJECT_ID('Libros') IS NOT NULL
	DROP TABLE Libros;
IF OBJECT_ID('Testamentos') IS NOT NULL
	DROP TABLE Testamentos;
IF OBJECT_ID('Versiones') IS NOT NULL
	DROP TABLE Versiones;
IF OBJECT_ID('Idiomas') IS NOT NULL
	DROP TABLE Idiomas;

IF OBJECT_ID('Idiomas') IS NOT NULL
BEGIN
	DROP TABLE Idiomas;
	PRINT 'Tabla eliminada'
END
ELSE
BEGIN
	PRINT 'tabla no existía'
END

CREATE TABLE Idiomas 
	(
		Id_Idioma		SMALLINT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
		Nombre			VARCHAR(20) NOT NULL
	);
PRINT 'Tabla Idiomas Creada';

IF OBJECT_ID('Versiones') IS NOT NULL
BEGIN
	DROP TABLE Versiones;
	PRINT 'Tabla eliminada'
END

CREATE TABLE Versiones 
	(
		Id_Version		SMALLINT IDENTITY(1, 1) NOT NULL, 
		NombreVersion	VARCHAR(30) NOT NULL, 
		SiglasVersion	VARCHAR(10) NOT NULL, 
		Traductor		VARCHAR(50), 
		FechaVersion	DATE, 
		Id_Idioma		SMALLINT,
		CONSTRAINT PK_Version
			PRIMARY KEY (Id_Version),
		CONSTRAINT FK_Idiom_Vers
			FOREIGN KEY (Id_Idioma)
				REFERENCES Idiomas(Id_Idioma)
	);
PRINT 'Tabla Versiones Creada';

ALTER TABLE Versiones
	DROP CONSTRAINT FK_Idiom_Vers;
	
alter table Versiones
	ADD CONSTRAINT FK_Idiom_Vers
		FOREIGN KEY (Id_Idioma)
			REFERENCES Idiomas(Id_Idioma);


IF OBJECT_ID('Testamentos') IS NOT NULL
BEGIN
	DROP TABLE Testamentos;
	PRINT 'Tabla Testamentos eliminada'
END
ELSE
BEGIN
	PRINT 'tabla no existía'
END
CREATE TABLE Testamentos(
		Id_Testamento	SMALLINT NOT NULL IDENTITY(1,1),
		Nombre			VARCHAR(20) NOT NULL,
		OrdenTest		tinyint not null,
		Id_Idioma		SMALLINT NOT NULL,
		PRIMARY KEY(Id_Testamento),
		FOREIGN KEY (Id_Idioma) REFERENCES Idiomas(Id_Idioma)
		);
PRINT 'Tabla Testamentos Creada';

IF OBJECT_ID('Libros') IS NOT NULL
BEGIN
	DROP TABLE Libros;
	PRINT 'Tabla Libros eliminada'
END
ELSE
BEGIN
	PRINT 'tabla no existía'
END		
CREATE TABLE Libros(
		Id_Libro		SMALLINT NOT NULL IDENTITY(1,1),
		Nombre			VARCHAR(20) NOT NULL,
		OrdenLibro		TINYINT NOT NULL,	--orden en específico que deben cumplir los libros
		CapitulosTot	TINYINT NOT NULL, --cantidad total de capítulos en ese libro
		Autor			VARCHAR(40) NULL,
		Año				SMALLINT NULL,
		Id_Testamento	SMALLINT NOT NULL,
		Id_Idioma		SMALLINT NOT NULL,
		CONSTRAINT PK_Libro
			PRIMARY KEY(Id_Libro),
		CONSTRAINT FK_Libro_Test
			FOREIGN KEY (Id_Testamento) --en esta tabla
				REFERENCES Testamentos(Id_Testamento), -- tabla en la cual está la PK
		CONSTRAINT FK_Libro_Idioma
			FOREIGN KEY (Id_Idioma) --en esta tabla
				REFERENCES Idiomas(Id_Idioma) -- tabla en la cual está la PK
		);
PRINT 'Tabla Libros Creada';		

IF OBJECT_ID('Versiculos') IS NOT NULL
BEGIN
	DROP TABLE Versiculos;
	PRINT 'Tabla Versiculos eliminada'
END
ELSE
BEGIN
	PRINT 'tabla no existía'
END

-- Es en esta tabla en la que se deben de capturar todos los textos bíblicos
-- y aquí es donde se va a hacer la navegación (Consulta)
-- y es en esta columna "Texto", donde se realizarán las búsquedas (por palabras)
CREATE TABLE Versiculos
(
		Id_Version		SMALLINT NOT NULL,
		Id_Libro		SMALLINT NOT NULL,
		NumeroCap		TINYINT NOT NULL,
		NumeroVers		TINYINT NOT NULL,
		Texto			TEXT NOT NULL,
		Id_Vers			SMALLINT NOT NULL IDENTITY(1,1),	-- esta columna ya solo queda informativa, no es PK
		CONSTRAINT PK_Versiculos
			PRIMARY KEY(Id_Version, Id_Libro, NumeroCap, NumeroVers),	--PK Compuesta
		CONSTRAINT FK_Vers_Libro
			FOREIGN KEY (Id_Libro) --en esta tabla
				REFERENCES Libros(Id_Libro), -- tabla en la cual está la PK		
		CONSTRAINT FK_Versiculo_Version
			FOREIGN KEY (Id_Version) --en esta tabla
				REFERENCES Versiones(Id_Version) -- tabla en la cual está la PK		
);
PRINT 'Tabla Versiculos Creada';


SELECT * FROM Libros