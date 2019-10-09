CREATE PROCEDURE sp_SystemLanguageEntry_get
	@languageId INT
AS
BEGIN

	SELECT
		Id,
		EntryKey,
		Translation,
		SystemLanguageId,
		CreatedDate,
		CreatedBy,
		UpdatedDate,
		UpdatedBy
	FROM		SystemLanguageEntry
	WHERE		SystemLanguageId = @languageId

END