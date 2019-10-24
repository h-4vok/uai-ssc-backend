CREATE PROCEDURE sp_SystemLanguageEntry_addOrUpdate
	@k NVARCHAR(500),
	@es NVARCHAR(MAX),
	@en NVARCHAR(MAX)
AS
BEGIN

	IF (@k = '')
	BEGIN
		RETURN
	END

	IF (EXISTS(SELECT TOP 1 1 FROM SystemLanguageEntry WHERE EntryKey = @k AND SystemLanguageId = 1))
	BEGIN
		
		UPDATE
			SystemLanguageEntry
		SET
			Translation = @es
		WHERE		EntryKey = @k
		AND			SystemLanguageId = 1

	END
	ELSE
	BEGIN
		
		INSERT SystemLanguageEntry (
			SystemLanguageId, EntryKey, Translation, CreatedBy, UpdatedBy
		)
		SELECT
			SystemLanguageId = 1,
			EntryKey = @k,
			Translation = @es,
			CreatedBy = 1,
			UpdatedBy = 1

	END

	IF (EXISTS(SELECT TOP 1 1 FROM SystemLanguageEntry WHERE EntryKey = @k AND SystemLanguageId = 2))
	BEGIN
		
		UPDATE
			SystemLanguageEntry
		SET
			Translation = @en
		WHERE		EntryKey = @k
		AND			SystemLanguageId = 2

	END
	ELSE
	BEGIN
		
		INSERT SystemLanguageEntry (
			SystemLanguageId, EntryKey, Translation, CreatedBy, UpdatedBy
		)
		SELECT
			SystemLanguageId = 2,
			EntryKey = @k,
			Translation = @en,
			CreatedBy = 1,
			UpdatedBy = 1

	END

END