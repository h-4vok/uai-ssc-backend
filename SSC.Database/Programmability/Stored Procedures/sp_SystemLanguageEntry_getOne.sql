CREATE PROCEDURE sp_SystemLanguageEntry_getOne
	@languageCode NVARCHAR(500),
	@key NVARCHAR(500)
AS
BEGIN

	SELECT
		sle.Id,
		sle.SystemLanguageId,
		sle.Translation,
		sle.EntryKey,
		sle.CreatedBy,
		sle.CreatedDate,
		sle.UpdatedBy,
		sle.UpdatedDate

	FROM		SystemLanguageEntry SLE

	INNER JOIN	SystemLanguage SL
			ON	sle.SystemLanguageId = sl.Id

	WHERE		sl.Code = @languageCode
	AND			sle.EntryKey = @key

END