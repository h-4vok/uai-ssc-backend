CREATE PROCEDURE sp_PlatformMenuItem_search
	@SearchTerm NVARCHAR(200),
	@LanguageCode NVARCHAR(500),
	@UserId INT
AS
BEGIN

	SELECT DISTINCT
		pmi.Id,
		pmi.MenuOrder,
		pmi.RelativeRoute,
		pmi.TranslationKey

	FROM		PlatformMenuItem PMI

	INNER JOIN	PlatformMenuItemPermission PMIP
			ON	pmi.Id = pmip.PlatformMenuItemId

	INNER JOIN	RolePermission RP
			ON	rp.PermissionId = pmip.PermissionId

	INNER JOIN	Role R
			ON	rp.RoleId = r.Id

	INNER JOIN	UserRole UR
			ON	ur.RoleId = r.Id

	INNER JOIN	SystemLanguageEntry SLE
			ON	pmi.TranslationKey = sle.EntryKey

	INNER JOIN	SystemLanguage SL
			ON	sle.SystemLanguageId = sl.Id

	WHERE		ur.UserId = @UserId
	AND			sl.Code = @LanguageCode
	AND			sle.Translation LIKE '%' + @SearchTerm + '%'

END