CREATE PROCEDURE sp_PlatformMenuItem_fullCreate
	@ParentMenuCode NVARCHAR(100),
	@MenuOrder INT,
	@RelativeRoute NVARCHAR(500),
	@TranslationKey NVARCHAR(500),
	@PermissionCode1 NVARCHAR(100),
	@PermissionCode2 NVARCHAR(100) = NULL,
	@PermissionCode3 NVARCHAR(100) = NULL,
	@PermissionCode4 NVARCHAR(100) = NULL
AS
BEGIN

	-- Find the menu
	DECLARE @MenuId INT
	SELECT @MenuId = Id FROM PlatformMenu WHERE Code = @ParentMenuCode
	
	-- Create the menu item
	DECLARE @MenuItemId INT
	EXEC sp_PlatformMenuItem_create @MenuId, @MenuOrder, @RelativeRoute, @TranslationKey, 1
	SELECT @MenuItemId = IDENT_CURRENT('PlatformMenuItem')

	-- Insert Permissions
	EXEC sp_PlatformMenuItemPermission_byCode @MenuItemId, @PermissionCode1
	EXEC sp_PlatformMenuItemPermission_byCode @MenuItemId, @PermissionCode2
	EXEC sp_PlatformMenuItemPermission_byCode @MenuItemId, @PermissionCode3
	EXEC sp_PlatformMenuItemPermission_byCode @MenuItemId, @PermissionCode4
	

END