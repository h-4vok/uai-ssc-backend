CREATE PROCEDURE sp_PlatformMenuItem_getByParentId
	@Id INT
AS
BEGIN

	SELECT
		pmi.Id,
		pmi.MenuOrder,
		pmi.PlatformMenuId,
		pmi.RelativeRoute,
		pmi.TranslationKey

	FROM		PlatformMenuItem PMI

	WHERE		pmi.PlatformMenuId = @Id

	ORDER BY	pmi.MenuOrder

END