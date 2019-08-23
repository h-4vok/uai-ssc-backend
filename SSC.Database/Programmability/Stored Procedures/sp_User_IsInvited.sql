CREATE PROCEDURE sp_User_IsInvited
	@userName NVARCHAR(200)	
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		UserInvitation UI

	WHERE		LOWER(ui.Email) = LOWER(@userName)
	AND			ui.IsUsed = 0

END