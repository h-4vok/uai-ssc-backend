CREATE PROCEDURE sp_Role_getAll
AS
BEGIN

	WITH CTE_RolePermissionCount AS (
		SELECT
			RoleId = rp.RoleId,
			Count = COUNT(DISTINCT rp.PermissionId)

		FROM		RolePermission rp
	
		GROUP BY
			rp.RoleId
	),
	CTE_RoleUserCount AS (
		SELECT
			RoleId = ur.RoleId,
			Count = COUNT(DISTINCT ur.UserId)

		FROM		UserRole UR

		GROUP BY
			ur.RoleId
	)
	SELECT
		Id = r.Id,
		Name = r.Name,
		IsEnabled = r.IsEnabled,
		QuantityOfUsers = ISNULL(ruc.Count, 0),
		QuantityOfPermissions = ISNULL(rpc.Count, 0)

	FROM		Role R

	LEFT  JOIN	CTE_RolePermissionCount RPC
			ON	r.Id = rpc.RoleId

	LEFT  JOIN	CTE_RoleUserCount RUC
			ON	r.Id = ruc.RoleId

END