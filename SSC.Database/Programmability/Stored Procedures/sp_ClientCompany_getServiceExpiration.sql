CREATE PROCEDURE sp_ClientCompany_getServiceExpiration
	@ClientId INT
AS
BEGIN

	SELECT
		ServicePlanExpirationDate

	FROM		ClientCompany

	WHERE		Id = @ClientId

END