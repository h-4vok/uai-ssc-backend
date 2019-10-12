CREATE PROCEDURE sp_SystemLanguageEntry_update
	@id INT,
	@translation NVARCHAR(500)
AS
BEGIN

	UPDATE	
		SystemLanguageEntry
	SET
		Translation = @translation
	WHERE
		Id = @id

END