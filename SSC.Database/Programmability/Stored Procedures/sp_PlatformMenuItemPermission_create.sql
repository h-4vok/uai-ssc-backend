CREATE PROCEDURE sp_PlatformMenuItemPermission_create
	@PlatformMenuId INT,
	@PermissionId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT PlatformMenuItemPermission (
		PlatformMenuId,
		PermissionId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		PlatformMenuId = @PlatformMenuId,
		PermissionId = @PermissionId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END