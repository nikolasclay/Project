Use DvdLibrary

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

Create Procedure DbReset AS

Begin
	Delete from Dvds;
	Set Identity_insert Dvds ON;

	Insert into Dvds (DvdId, Title, ReleaseYear, DirectorName, RatingType, Notes)
	Values (1, 'True Hollywood Stories', 2017, 'Charlie Murphy', 'R', 'Game, blouses.'),
		   (2, 'East West Bowl', 1999, 'Hingle McCringleberry', 'R', 'A movie so bad, it''s good!'),
		   (3, 'The Mad Real World', 2012, 'Tron', 'R', 'Hot hand in the dice game, baby!')

Set Identity_insert Dvds OFF;
End