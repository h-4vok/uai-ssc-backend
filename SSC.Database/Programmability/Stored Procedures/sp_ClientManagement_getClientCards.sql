CREATE PROCEDURE sp_ClientManagement_getClientCards
	@ClientId INT
AS
BEGIN

	SELECT	
		acc.Id,
		acc.Number,
		acc.Owner,
		acc.ExpirationDateMMYY,
		acc.CCV

	FROM		ClientCompanyCreditCard ACC

END