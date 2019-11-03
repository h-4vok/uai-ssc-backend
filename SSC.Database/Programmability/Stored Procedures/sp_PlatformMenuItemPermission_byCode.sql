CREATE PROCEDURE sp_PlatformMenuItemPermission_byCode
	@MenuItemId INT,
	@PermissionCode NVARCHAR(100) = NULL
AS
BEGIN

	IF(@PermissionCode IS NULL)
	BEGIN
		RETURN
	END

	INSERT PlatformMenuItemPermission (
		PlatformMenuItemId,
		PermissionId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		PlatformMenuItemId = @MenuItemId,
		PermissionId = Id,
		CreatedBy = 1,
		UpdatedBy = 1
	FROM		Permission
	WHERE		Code = @PermissionCode

END