CREATE PROCEDURE sp_RolePermission_delete
	@roleId INT
AS
BEGIN

	DELETE	RolePermission
	WHERE	RoleId = @roleId

END