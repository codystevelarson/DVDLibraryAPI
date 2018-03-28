USE [master];

DECLARE @kill varchar(8000) = '';  
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('DvdLibraryADO')

EXEC(@kill);

if exists (select * from sysdatabases where name='DvdLibraryADO')
		drop database DvdLibraryADO
GO

CREATE DATABASE DvdLibraryADO
GO

USE DvdLibraryADO
GO

CREATE TABLE Dvds (
	DvdID INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(100) NOT NULL,
	ReleaseYear INT NOT NULL,
	Director NVARCHAR(50) NOT NULL,
	Rating NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(180)
)