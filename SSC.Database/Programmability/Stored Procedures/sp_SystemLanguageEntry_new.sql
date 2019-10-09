CREATE PROCEDURE sp_SystemLanguageEntry_new
	@key NVARCHAR(500),
	@defaultTranslation NVARCHAR(500),
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
		SystemLanguageId = lang.Id,
		Translation = @defaultTranslation,
		CreatedBy = @createdBy,
		UpdatedBy = @createdBy
	FROM		SystemLanguage LANG

END
