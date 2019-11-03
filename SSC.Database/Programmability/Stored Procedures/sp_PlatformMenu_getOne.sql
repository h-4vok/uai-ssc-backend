CREATE PROCEDURE sp_PlatformMenu_getOne
	@Id INT
AS
BEGIN

	SELECT
		Id,
		Code,
		MenuOrder,
		TranslationKey

	FROM		PlatformMenu

	WHERE		Id = @Id

END