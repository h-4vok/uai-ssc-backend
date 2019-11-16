CREATE PROCEDURE sp_ClientManagement_getApprovedCards
AS
BEGIN

	SELECT	
		acc.Id,
		acc.Number,
		acc.Owner,
		acc.ExpirationDateMMYY,
		acc.CCV

	FROM		ApprovedCreditCard ACC
	
END