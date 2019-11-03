CREATE PROCEDURE sp_PlatformMenu_get
AS
BEGIN

	SELECT
		Id,
		Code,
		MenuOrder,
		TranslationKey

	FROM		PlatformMenu

END