CREATE PROCEDURE sp_SampleTypeParameter_exists
	@Code NVARCHAR(100),
	@CurrentId INT = NULL
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		SampleTypeParameter STP

	WHERE		(@CurrentId IS NULL OR (@CurrentId IS NOT NULL AND stp.Id = @CurrentId))
	AND			stp.Code = @Code

END