CREATE PROCEDURE sp_User_registerLoginFailure
	@userName NVARCHAR(200),
	@count INT,
	@block BIT
AS
BEGIN

	UPDATE TOP (1)
		PlatformUser
	SET
		LoginFailures = @count,
		IsBlocked = @block

	WHERE		UserName = @userName

END