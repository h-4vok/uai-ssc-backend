CREATE PROCEDURE sp_PlatformMenu_clean
	@Id INT
AS
BEGIN

	-- Delete permissions
	DELETE per
	FROM		PlatformMenuItemPermission PER
	INNER JOIN	PlatformMenuItem PMI
			ON	per.PlatformMenuItemId= pmi.Id
	WHERE		pmi.PlatformMenuId = @Id

	-- Delete menu items
	DELETE PlatformMenuItem WHERE PlatformMenuId = @Id

END