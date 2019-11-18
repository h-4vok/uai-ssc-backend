CREATE PROCEDURE sp_ClientCompany_updateExpirationDate
	@Id INT,
	@ServiceExpirationDate SMALLDATETIME
AS
BEGIN

	UPDATE
		ClientCompany

	SET
		ServicePlanExpirationDate = @ServiceExpirationDate

	WHERE
		Id = @Id

END