CREATE PROCEDURE sp_SystemLanguage_getEntry
	@id int
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

	WHERE		Id = @id

END