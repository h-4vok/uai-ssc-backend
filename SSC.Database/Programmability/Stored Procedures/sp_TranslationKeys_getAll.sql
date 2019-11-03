CREATE PROCEDURE sp_TranslationKeys_getAll
AS
BEGIN

	SELECT DISTINCT
		TranslationKey = EntryKey

	FROM		SystemLanguageEntry

END