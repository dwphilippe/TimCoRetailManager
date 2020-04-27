CREATE PROCEDURE [dbo].[spUserLookup]
	@id nvarchar(128)
AS
	SET NOCOUNT ON; 

	SELECT Id, FirstName, LastName, u.EmailAddress, u.CreateDate
	FROM [dbo].[User] u
	where Id = @id;

RETURN 0
