CREATE PROCEDURE sp_User_exists
	@userName NVARCHAR(200)
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		PlatformUser PU

	WHERE		pu.UserName = @userName

END