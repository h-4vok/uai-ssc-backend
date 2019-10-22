CREATE PROCEDURE sp_SystemLanguageEntry_buildDefaultDictionary
AS
BEGIN

	DECLARE @langId INT
	SELECT @langId = Id FROM SystemLanguage WHERE Code = 'es'

	SELECT
		r = '/* eslint-disable */'

		UNION ALL

	SELECT
		r = 'export const defaultDictionary = {'

		UNION ALL

	SELECT
		r = '''' + EntryKey + ''': ''' + Translation + ''','

	FROM		SystemLanguageEntry

	WHERE		SystemLanguageId = @langId

		UNION ALL

	SELECT
		r = '};'

END