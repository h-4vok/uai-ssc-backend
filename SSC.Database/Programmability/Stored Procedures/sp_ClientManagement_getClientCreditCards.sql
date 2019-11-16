CREATE PROCEDURE sp_ClientManagement_getClientCreditCards
	@ClientId INT
AS
BEGIN

	SELECT
		cc.Id,
		cc.Owner,
		cc.Number,
		cc.ExpirationDateMMYY,
		cc.CCV

	FROM		ClientCompanyCreditCard CC

	WHERE		CC.ClientId = @ClientId

END