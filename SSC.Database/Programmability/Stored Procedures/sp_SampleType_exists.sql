CREATE PROCEDURE sp_SampleType_exists
	@Name NVARCHAR(500),
	@CurrentId INT = NULL
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		SampleType

	WHERE		Name = @Name

	AND			(@CurrentId IS NULL OR (@CurrentId IS NOT NULL AND Id <> @CurrentId))

END