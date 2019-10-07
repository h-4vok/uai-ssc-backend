CREATE PROCEDURE sp_Role_exists
	@name NVARCHAR(300),
	@currentId INT = NULL
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		[Role] R

	WHERE		UPPER(r.Name) = UPPER(@name)
	AND			(@currentId IS NULL OR (@currentId IS NOT NULL AND @currentId <> r.Id))

END