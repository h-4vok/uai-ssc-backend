CREATE PROCEDURE sp_User_getReport
	@roles ListOfIds READONLY,
	@permissions ListOfIds READONLY
AS
BEGIN

	DECLARE @skipRoleFilter BIT = 1
	DECLARE @skipPermissionFilter BIT = 1

	IF (EXISTS(SELECT TOP 1 1 FROM @roles))
	BEGIN
		SET @skipRoleFilter = 0
	END

	IF (EXISTS(SELECT TOP 1 1 FROM @permissions))
	BEGIN
		SET @skipPermissionFilter = 0
	END

	;

	WITH CTE_UsersWithPlaformRole (UserId)
	AS (
		SELECT DISTINCT
			UserId = pu.Id

		FROM		PlatformUser PU
		
		INNER JOIN	UserRole UR
				ON	pu.Id = ur.UserId

		INNER JOIN	Role R
				ON	ur.RoleId = r.Id

		WHERE		r.IsPlatformRole = 1
	)
	SELECT
		Id = pu.Id,
		ClientName = cc.Name,
		IsDisabled = CONVERT(BIT, CASE WHEN pu.IsEnabled = 1 THEN 0 ELSE 1 END),
		IsBlocked = pu.IsBlocked,
		CountOfRoles = ISNULL(COUNT(DISTINCT ur.RoleId), 0),
		CountOfPermissions = ISNULL(COUNT(DISTINCT rp.PermissionId), 0),
		IsPlatformAdmin = CONVERT(BIT, CASE WHEN uwpr.UserId IS NOT NULL THEN 1 ELSE 0 END)

	FROM		PlatformUser PU

	LEFT  JOIN	ClientCompany CC
			ON	pu.ClientId = cc.Id

	LEFT  JOIN	UserRole UR
			ON	pu.Id = ur.UserId

	LEFT  JOIN	Role R
			ON	ur.RoleId = r.Id

	LEFT  JOIN	RolePermission RP
			ON	r.Id = rp.RoleId

	LEFT  JOIN	CTE_UsersWithPlaformRole UWPR
			ON	pu.Id = uwpr.UserId

	WHERE		@skipRoleFilter = 1 OR (ur.Id IN (SELECT Id FROM @roles))
	AND			@skipPermissionFilter = 1 OR (rp.Id IN (SELECT Id From @permissions))

	GROUP BY
		pu.Id,
		cc.Name,
		pu.IsEnabled,
		pu.IsBlocked,
		uwpr.UserId

END