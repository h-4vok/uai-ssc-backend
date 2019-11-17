CREATE PROCEDURE sp_ClientCompany_updateServiceExpiration
	@ServicePlanExpirationTime SMALLDATETIME,
	@ClientId INT
AS
BEGIN

	UPDATE
		ClientCompany

	SET
		ServicePlanExpirationDate = @ServicePlanExpirationTime

	WHERE
		Id = @ClientId

END