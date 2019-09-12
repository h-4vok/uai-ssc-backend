CREATE PROCEDURE sp_ClientCompanyBillingInformation_taxCodeExists
	@taxCode NVARCHAR(16)
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)
	FROM		ClientCompanyBillingInformation
	WHERE		TaxCode = @taxCode

END