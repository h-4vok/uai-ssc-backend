CREATE PROCEDURE sp_User_getSessionData
	@userName NVARCHAR(200)
AS
BEGIN

	SELECT
		UserId = pu.Id,
		UserName = pu.UserName,
		ClientId = ISNULL(pu.ClientId, 0),
		ClientApiKey = ISNULL(cc.ApiToken, '')

	FROM		PlatformUser PU

	LEFT  JOIN	ClientCompany CC
			ON	pu.ClientId = cc.Id

END