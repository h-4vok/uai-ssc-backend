CREATE PROCEDURE sp_PlatformMenuItemPermission_create
	@PlatformMenuItemId INT,
	@PermissionId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT PlatformMenuItemPermission (
		PlatformMenuItemId,
		PermissionId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		PlatformMenuItemId = @PlatformMenuItemId,
		PermissionId = @PermissionId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END