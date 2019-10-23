CREATE PROCEDURE sp_PlatformUser_updatePassword
	@UserName NVARCHAR(200),
	@NewPassword NVARCHAR(200)
AS
BEGIN

	UPDATE
		PlatformUser
	SET
		Password = @NewPassword
	WHERE
		UserName = @UserName

END