CREATE PROCEDURE sp_User_getFull
	@userName NVARCHAR(200)
AS
BEGIN

	SELECT
		Id = pu.Id,
		UserName = pu.UserName,
		Password = pu.Password,
		IsBlocked = pu.IsBlocked,
		IsDisabled = CONVERT(BIT, CASE WHEN pu.IsEnabled = 1 THEN 0 ELSE 1 END),
		LoginFailures = pu.LoginFailures,
		CreatedDate = pu.CreatedDate,
		CreatedBy = pu.CreatedBy,
		UpdatedDate = pu.UpdatedDate,
		UpdatedBy = pu.UpdatedBy,
		RoleId = r.Id,
		RoleName = r.Name,
		RoleIsPlatformRole = r.IsPlatformRole,
		PermissionId = p.Id,
		PermissionCode = p.Code,
		PermissionName = p.Name

	FROM		PlatformUser PU

	LEFT  JOIN	UserRole UR
			ON	pu.Id = ur.UserId

	LEFT  JOIN	Role R
			ON	ur.RoleId = r.Id

	LEFT  JOIN	RolePermission RP
			ON	r.Id = rp.RoleId

	LEFT  JOIN	Permission P
			ON	rp.PermissionId = p.Id

END