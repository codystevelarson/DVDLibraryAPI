USE DvdLibraryADO
GO


--Get All--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAll'
)
BEGIN 
	DROP PROCEDURE GetAll
END 
GO

CREATE PROCEDURE GetAll
AS
BEGIN
SELECT * FROM Dvds
END
GO


--Get--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvd'
)
BEGIN 
	DROP PROCEDURE GetDvd
END 
GO

CREATE PROCEDURE GetDvd(
	@DvdID INT
)
AS
BEGIN
SELECT * FROM Dvds
WHERE DvdID = @DvdID
END
GO



--GetAllByTitle--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllByTitle'
)
BEGIN 
	DROP PROCEDURE GetAllByTitle
END 
GO

CREATE PROCEDURE GetAllByTitle(
	@Title NVARCHAR(100)
)
AS
BEGIN
SELECT * FROM Dvds
WHERE Title LIKE CONCAT('%', @Title, '%')
END
GO



--GetAllByYear--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllByYear'
)
BEGIN 
	DROP PROCEDURE GetAllByYear
END 
GO

CREATE PROCEDURE GetAllByYear(
	@ReleaseYear INT
)
AS
BEGIN
SELECT * FROM Dvds
WHERE ReleaseYear = @ReleaseYear
END
GO


--GetAllByRating--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllByRating'
)
BEGIN 
	DROP PROCEDURE GetAllByRating
END 
GO

CREATE PROCEDURE GetAllByRating(
	@Rating NVARCHAR(10)
)
AS
BEGIN
SELECT * FROM Dvds
WHERE Rating = @Rating
END
GO


--GetAllByDirector--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllByDirector'
)
BEGIN 
	DROP PROCEDURE GetAllByDirector
END 
GO

CREATE PROCEDURE GetAllByDirector(
	@Director NVARCHAR(50)
)
AS
BEGIN
SELECT * FROM Dvds
WHERE Director LIKE CONCAT('%', @Director, '%')
END
GO


--Create--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateDvd'
)
BEGIN 
	DROP PROCEDURE CreateDvd
END 
GO

CREATE PROCEDURE CreateDvd(
	@DvdID INT OUTPUT,
	@Title NVARCHAR(100),
	@ReleaseYear INT,
	@Director NVARCHAR(50),
	@Rating NVARCHAR(10),
	@Notes NVARCHAR(180)
)
AS
BEGIN

INSERT INTO Dvds (Title,ReleaseYear,Director,Rating,Notes)
	VALUES(@Title,@ReleaseYear,@Director,@Rating,@Notes)
	 SET @DvdID = SCOPE_IDENTITY()
END
GO


--Update--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateDvd'
)
BEGIN 
	DROP PROCEDURE UpdateDvd
END 
GO

CREATE PROCEDURE UpdateDvd(
	@DvdID INT,
	@Title NVARCHAR(100),
	@ReleaseYear INT,
	@Director NVARCHAR(50),
	@Rating NVARCHAR(10),
	@Notes NVARCHAR(180)
)
AS
BEGIN

UPDATE Dvds
	SET 
		Title = @Title,
		ReleaseYear = @ReleaseYear,
		Director = @Director,
		Rating = @Rating,
		Notes = @Notes
	WHERE DvdID = @DvdID
END
GO



--Delete--
IF EXISTS (
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteDvd'
)
BEGIN
	DROP PROCEDURE DeleteDvd
END
GO

CREATE PROCEDURE DeleteDvd(
	@DvdID INT
)
AS
BEGIN

DELETE FROM Dvds
WHERE DvdID = @DvdID

END
GO



--ResetDB--
IF EXISTS (
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ResetDB'
)
BEGIN
	DROP PROCEDURE ResetDB
END
GO

CREATE PROCEDURE ResetDB
AS
BEGIN



DELETE FROM Dvds;
SET IDENTITY_INSERT Dvds ON;
INSERT INTO Dvds (DvdId,Title,ReleaseYear,Rating,Director,Notes)
	VALUES(1,'Good Burger', 1997, 'G', 'Brian Robbins', 'Classic Movie - Orange (VHS)'),
		(2,'The Impossible Kid', 1982, 'NR', 'Eddie Nicart', 'Weng Weng''s finest performace!'),
		(3,'Logans Run', 1976, 'PG', 'Michael Anderson', NULL),
		(4,'Blue Velvet', 1986, 'R', 'David Lynch', 'A David Lynch movie you can safetly recommend without lengthy explination'),
		(5,'The Life Aquatic with Steve Zissou', 2004, 'R', 'Wes Anderson', 'Best Wes Anderson Flick IMO'),
		(6,'Rush Hour 3', 2007, 'PG-13', 'Brett Ratner', 'A chemistry as viscous as Chris Tucker and Jackie Chan''s has yet to be topped'),
		(7,'Eraserhead', 1977, 'NR', 'David Lynch','Something to put on at a halloween party on mute with music playing'),
		(8,'Wake In Fright', 1971, 'R', 'Ted Kotcheff', NULL),
		(9,'El Topo', 1970, 'NR', 'Alejandro Jodorowsky', 'Most watchable Jodorowsky movie'),
		(10,'Toe Story', 1995, 'G', 'John Lasseter', NULL),
		(11,'The Mist', 2007, 'R', 'Frank Darabont', 'Best to watch the black and white version');
SET IDENTITY_INSERT Dvds OFF;
END
