CREATE PROCEDURE sp_SampleFunction_exists
	@TenantId INT,
	@Code NVARCHAR(500),
	@CurrentId INT = NULL
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		SampleFunction

	WHERE		TenantId = @TenantId
	AND			Code = @Code
	AND			(@CurrentId IS NULL OR (@CurrentId IS NOT NULL AND Id <> @CurrentId))

END