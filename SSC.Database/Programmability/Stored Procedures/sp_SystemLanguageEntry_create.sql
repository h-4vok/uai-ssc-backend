CREATE PROCEDURE sp_SystemLanguageEntry_create
	@key NVARCHAR(500),
	@translation NVARCHAR(500),
	@languageId INT,
	@createdBy INT
AS
BEGIN

	INSERT SystemLanguageEntry (
		EntryKey,
		SystemLanguageId,
		Translation,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		EntryKey = @key,
		SystemLanguageId = @languageId,
		Translation = @translation,
		CreatedBy = @createdBy,
		UpdatedBy = @createdBy

	SELECT SCOPE_IDENTITY()

END
