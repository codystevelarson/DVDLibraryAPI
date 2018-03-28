USE [master]
GO 

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO


USE DvdLibraryADO
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO


CREATE ROLE db_dvdAdmin

GRANT EXECUTE TO db_dvdAdmin

ALTER ROLE db_dvdAdmin ADD MEMBER DvdLibraryApp

GRANT SELECT ON Dvds TO DvdLibraryApp
GRANT INSERT ON Dvds TO DvdLibraryApp
GRANT UPDATE ON Dvds TO DvdLibraryApp
GRANT DELETE ON Dvds TO DvdLibraryApp
GRANT ALTER ON Dvds TO DvdLibraryApp
GO