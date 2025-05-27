/*
Script para la inserción de datos de la Biblia
Autor: Alejandro Villarreal
Fecha: 19-Marzo-2023
MAD 
Ene-Jun 2024
LMAD

*/


Use DB_Bible;
-- Confirmar que la BD y las tablas ya estén creadas y vacías antes de ejecutar este script

INSERT INTO Idiomas(Nombre) VALUES('Español');
INSERT INTO Idiomas(Nombre) VALUES('Inglés');
INSERT INTO Idiomas(Nombre) VALUES('Francés');
INSERT INTO Idiomas(Nombre) VALUES('Italiano');
INSERT INTO Idiomas(Nombre) VALUES('Alemán');
-- aquí pueden agregar más idiomas si así lo requieren


INSERT Versiones(NombreVersion, Traductor, FechaVersion, SiglasVersion, Id_Idioma) 
			VALUES('REINA VALERA 1960', 'Casiodoro de Reina y Cipriano de Valera', null, 'RV60', 1);
INSERT Versiones(NombreVersion, Traductor, FechaVersion, SiglasVersion, Id_Idioma) 
			VALUES('NUEVA VERSION INTERNACIONAL', NULL, null, 'NVI', 1);
INSERT Versiones(NombreVersion, Traductor, FechaVersion, SiglasVersion, Id_Idioma) 
			VALUES('ANTIGUA REINA VALERA', 'Casiodoro de Reina y Cipriano de Valera', null, 'ARV', 1);
INSERT Versiones(NombreVersion, Traductor, FechaVersion, SiglasVersion, Id_Idioma) 
			VALUES('KING JAMES', NULL, null, 'KJV',2);
INSERT Versiones(NombreVersion, Traductor, FechaVersion, SiglasVersion, Id_Idioma) 
			VALUES('NEW INTERNATIONAL VERSION', NULL, null, 'NIV',2);
-- la versión a utilizar es la RV60
-- idioma a utilizar: Español

-- se va a utilizar esa versión, porque la conseguí completa en un archivo texto y de ahí pueden generar
-- los INSERT que se requieran


--Datos para el idioma español
insert Testamentos(Id_Idioma, Nombre, OrdenTest) values(1, 'ANTIGUO TESTAMENTO', 1)
insert Testamentos(Id_Idioma, Nombre, OrdenTest) values(1, 'NUEVO TESTAMENTO', 2)

--Datos para el idioma inglés
insert Testamentos(Id_Idioma, Nombre, OrdenTest) values(2, 'OLD TESTAMENT', 1)
insert Testamentos(Id_Idioma, Nombre, OrdenTest) values(2, 'NEW TESTAMENT', 2)


--insertar todos los libros en español
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Moisés',1,'Génesis', 50, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Moisés',2,'Exodo', 40, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Moisés',3,'Levítico', 27, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Moisés',4,'Números', 36, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Moisés',5,'Deuteronomio', 34, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Josué',6,'Josué', 24, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('varios',7,'Jueces', 21, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('desconocido',8,'Ruth', 4, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Samuel',9,'1 Samuel', 31, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('desconocido',10,'2 Samuel', 24, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Jeremías',11,'1 Reyes', 22, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Jeremías',12,'2 Reyes', 25, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('desconocido',13,'1 Crónicas', 29, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('desconocido',14,'2 Crónicas', 36, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Esdras',15,'Esdras', 10, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Nehemías',16,'Nehemías', 13, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('desconocido',17,'Esther', 10, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Moisés',18,'Job', 42, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Varios',19,'Salmos', 150, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('varios',20,'Proverbios', 31, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Salomón',21,'Eclesiastés', 12, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Salomón',22,'Cantar de Cantares', 8, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Isaías',23,'Isaías', 66, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Jeremías',24,'Jeremías', 52, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Jeremías',25,'Lamentaciones', 5, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Ezequiel',26,'Ezequiel', 48, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Daniel',27,'Daniel', 12, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Oseas',28,'Oseas', 14, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Joel',29,'Joel', 3, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Amós',30,'Amós', 9, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Abdías',31,'Abdías', 1, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Jonás',32,'Jonás', 4, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Miqueas',33,'Miqueas', 7, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Nahum',34,'Nahum', 3, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Habacuc',35,'Habacuc', 3, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Sofonías',36,'Sofonías', 3, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Hageo',37,'Hageo', 2, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Zacarías',38,'Zacarías', 14, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Malaquías',39,'Malaquías', 4, 1, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Mateo',40,'Mateo', 28, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Marcos',41,'Marcos', 16, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Lucas',42,'Lucas', 24, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Juan',43,'Juan', 21, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Lucas',44,'Hechos', 28, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',45,'Romanos', 16, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',46,'1 Corintios', 16, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',47,'2 Corintios', 13, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',48,'Gálatas', 6, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',49,'Efesios', 6, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',50,'Filipenses', 4, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',51,'Colosenses', 4, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',52,'1 Tesalonisenses', 5, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',53,'2 Tesalonisenses', 3, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',54,'1 Timoteo', 6, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',55,'2 Timoteo', 4, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',56,'Tito', 3, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pablo',57,'Filemón', 1, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('desconocido',58,'Hebreos', 13, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Santiago',59,'Santiago', 5, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pedro',60,'1 Pedro', 5, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Pedro',61,'2 Pedro', 3, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Juan',62,'1 Juan', 5, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Juan',63,'2 Juan', 1, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Juan',64,'3 Juan', 1, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Judas',65,'Judas', 1, 2, 1);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values('Juan',66,'Apocalipsis', 22, 2, 1);

--insertar todos los libros en inglés
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,1,'Genesis', 50, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,2,'Exodus', 40, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,3,'Leviticus', 27, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,4,'Numbers', 36, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,5,'Deuteronomy', 34, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,6,'Joshua', 24, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,7,'Judges', 21, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,8,'Ruth', 4, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,9,'1 Samuel', 31, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,10,'2 Samuel', 24, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,11,'1 Kings', 22, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,12,'2 Kings', 25, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,13,'1 Chronicles', 29, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,14,'2 Chronicles', 36, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,15,'Ezra', 10, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,16,'Nehemiah', 13, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,17,'Esther', 10, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,18,'Job', 42, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,19,'Psalm', 150, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,20,'Proverbs', 31, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,21,'Ecclesiastes', 12, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,22,'Song of Solomon', 8, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,23,'Isaiah', 66, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,24,'Jeremiah', 52, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,25,'Lamentations', 5, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,26,'Ezekiel', 48, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,27,'Daniel', 12, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,28,'Hosea', 14, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,29,'Joel', 3, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,30,'Amos', 9, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,31,'Obadiah', 1, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,32,'Jonah', 4, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,33,'Micah', 7, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,34,'Nahum', 3, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,35,'Habakkuk', 3, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,36,'Zephaniah', 3, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,37,'Haggai', 2, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,38,'Zechariah', 14, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,39,'Malachi', 4, 3, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,40,'Matthew', 28, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,41,'Mark', 16, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,42,'Luke', 24, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,43,'John', 21, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,44,'Acts', 28, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,45,'Romans', 16, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,46,'1 Corinthians', 16, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,47,'2 Corinthians', 13, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,48,'Galatians', 6, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,49,'Ephesians', 6, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,50,'Philippians', 4, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,51,'Colossians', 4, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,52,'1 Thessalonians', 5, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,53,'2 Thessalonians', 3, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,54,'1 Timothy', 6, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,55,'2 Timothy', 4, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,56,'Titus', 3, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,57,'Philemon', 1, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,58,'Hebrews', 13, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,59,'James', 5, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,60,'1 Peter', 5, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,61,'2 Peter', 3, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,62,'1 John', 5, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,63,'2 John', 1, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,64,'3 John', 1, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,65,'Jude', 1, 4, 2);
INSERT INTO Libros(Autor, OrdenLibro, Nombre, CapitulosTot, Id_Testamento, Id_Idioma) values(null,66,'Revelation', 22, 4, 2);


/*
Select * from Idiomas;
select * from Versiones;
select * from Testamentos;
select * from Libros
select * from Versiculos
*/

/*
select A.Id_Version, A.NombreVersion, B.Nombre Testamento, B.Id_Testamento, upper(C.Nombre) Libro, C.CapitulosTot, C.Id_Libro
from Versiones A
	inner join Testamentos B
		On A.Id_Idioma = B.Id_Idioma
	inner join Libros C
		On B.Id_Testamento = C.Id_Testamento
		and B.Id_Idioma		= C.Id_Idioma
	Where A.Id_Version = 2
Order by A.Id_Version, B.Id_Testamento, C.OrdenLibro;

*/


/*
página de referencia:

https://www.biblegateway.com/passage/?search=G%C3%A9nesis%201&version=NVI

revisar archivo texto adjunto con todos los textos de la versión RV60
y de ahí se pueden tomar los textos a insertar que les correspondan a cada equipo, de cada grupo

*/

-- Ejemplo de cómo insertar los textos, para el Libro de Génesis (Id = 1), de la versión NVI (Id = 2)
-- recuerden que la PK de esta tabla es Version, Libro, NumeroCap, NumeroVers, para evitar que se duplique información

-- cada equipo debe de preparar los INSERT de 3 capítulos...

insert into Versiculos (Id_Version, Id_Libro, NumeroCap, NumeroVers, Texto) Values (2, 1, 1, 1, 'En el principio Dios creó los cielos y la tierra.');
insert into Versiculos (Id_Version, Id_Libro, NumeroCap, NumeroVers, Texto) Values (2, 1, 1, 2, 'La tierra no tenía forma y estaba vacía, las tinieblas cubrían el abismo y el Espíritu de Dios se movía sobre la superficie de las aguas.');
insert into Versiculos (Id_Version, Id_Libro, NumeroCap, NumeroVers, Texto) Values (2, 1, 1, 3, 'Y dijo Dios: «¡Que haya luz!». Y la luz llegó a existir.');
insert into Versiculos (Id_Version, Id_Libro, NumeroCap, NumeroVers, Texto) Values (2, 1, 1, 4, 'Dios consideró que la luz era buena y la separó de las tinieblas.');
insert into Versiculos (Id_Version, Id_Libro, NumeroCap, NumeroVers, Texto) Values (2, 1, 1, 5, 'A la luz la llamó «día» y a las tinieblas, «noche». Vino la noche y llegó la mañana: ese fue el primer día.');


select * from Versiones

