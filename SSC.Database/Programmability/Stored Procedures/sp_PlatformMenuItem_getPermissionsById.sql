CREATE PROCEDURE sp_PlatformMenuItem_getPermissionsById
	@MenuItemId INT
AS
BEGIN
	
	SELECT 
		p.Id, 
		p.Code

	FROM		PlatformMenuItemPermission PMIP

	INNER JOIN	Permission P
			ON	pmip.PermissionId = p.Id

	WHERE		pmip.PlatformMenuItemId = @MenuItemId

END