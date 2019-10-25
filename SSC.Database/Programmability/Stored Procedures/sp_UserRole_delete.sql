CREATE PROCEDURE sp_UserRole_delete
	@UserId INT
AS
BEGIN

	DELETE
		UserRole
	WHERE
		UserId = @UserId

END