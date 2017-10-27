USE master
GO

IF EXISTS (SELECT LoginName FROM master.dbo.syslogins WHERE NAME = 'DvdLibraryApp')
DROP LOGIN DvdLibraryApp

CREATE LOGIN  DvdLibraryApp WITH PASSWORD ='testing123';
GO


USE DvdLibrary
GO
IF Exists (SELECT * FROM sys.database_principals
		   WHERE NAME = 'DvdLibraryApp')
	DROP USER DvdLibraryApp

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE TO [DvdLibraryApp]
GRANT SELECT ON Dvds TO DvdLibraryApp
GRANT INSERT ON Dvds TO DvdLibraryApp
GRANT UPDATE ON Dvds TO DvdLibraryApp
GRANT DELETE ON Dvds TO DvdLibraryApp
GRANT SELECT ON Dvds TO DvdLibraryApp
GRANT INSERT ON Dvds TO DvdLibraryApp
GRANT UPDATE ON Dvds TO DvdLibraryApp
GRANT DELETE ON Dvds TO DvdLibraryApp
GO