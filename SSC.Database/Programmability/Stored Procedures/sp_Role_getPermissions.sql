CREATE PROCEDURE sp_Role_getPermissions
	@roleId INT
AS
BEGIN

	SELECT
		p.Id,
		p.Name,
		p.Code,
		p.CreatedBy,
		p.UpdatedBy,
		p.CreatedDate,
		p.UpdatedDate

	FROM		RolePermission RP

	INNER JOIN	Permission P
			ON	rp.PermissionId = p.Id

	WHERE		rp.RoleId = @roleId

END