CREATE PROCEDURE sp_User_IsEnabled
	@UserName NVARCHAR(200)
AS
BEGIN

	SELECT IsEnabled FROM PlatformUser WHERE UserName = @UserName

END