CREATE PROCEDURE sp_RolePermission_add
	@roleId INT,
	@permissionId INT,
	@createdBy INT
AS
BEGIN

	INSERT RolePermission (
		RoleId,
		PermissionId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		RoleId = @roleId,
		PermissionId = @permissionId,
		CreatedBy = @createdBy,
		UpdatedBy = @createdBy

END