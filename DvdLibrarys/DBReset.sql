IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Dvds;
	

	DBCC CHECKIDENT ('Dvds', RESEED, 1)

	INSERT INTO Dvds (Title, ReleaseYear, Rating, DirectorName)
	VALUES ('FaceOff', 1997, 'PG', 'John Woo'),
	       ('Hitch', 2005, 'R', 'Ali Hirsi'),
               ('pulp Fiction', 1997, 'PG', 'JQuentin Tarantino'),
               ('The Pursuit of Happiness', 2006, 'P', 'Gabriele Muccino'),
               ('Suburbicon', 2017, 'PG-13', 'Matt Damon'),
	            ('Madia Goes To Jail', 2014, 'R', 'Tyler Perry');
	END