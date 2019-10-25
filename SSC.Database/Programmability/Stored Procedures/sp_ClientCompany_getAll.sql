CREATE PROCEDURE sp_ClientCompany_getAll
AS
BEGIN

	SELECT
		Id = cc.Id,
		BalanceStatusDescription = NULL, -- TODO
		IsEnabled = cc.IsEnabled,
		LastBillExpirationDate = GETDATE(), -- TODO
		LegalName = ccbi.LegalName,
		SelectedPaymentType = 'Credit Card',
		SelectedPlanDescription = pp.Name,
		TaxCode = ccbi.TaxCode

	FROM		ClientCompany CC

	LEFT  JOIN	ClientCompanyBillingInformation CCBI
			ON	cc.Id = ccbi.Id

	LEFT  JOIN	ClientCompanyCreditCard CCCC
			ON	cc.Id = cccc.ClientId
			AND	cccc.IsDefault = 1

	LEFT  JOIN	PricingPlan PP
			ON	cc.CurrentPricingPlanId = pp.Id

END