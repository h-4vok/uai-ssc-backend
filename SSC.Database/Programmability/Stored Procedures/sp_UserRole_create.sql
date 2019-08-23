CREATE PROCEDURE sp_UserRole_create
	@userId INT,
	@roleId INT,
	@createdBy INT
AS
BEGIN

	INSERT UserRole (
		UserId,
		RoleId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		UserId = @userId,
		RoleId = @roleId,
		CreatedBy = @createdBy,
		UpdatedBy = @createdBy

	SELECT SCOPE_IDENTITY()

END