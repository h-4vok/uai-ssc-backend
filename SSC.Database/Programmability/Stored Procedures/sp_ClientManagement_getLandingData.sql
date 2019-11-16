CREATE PROCEDURE sp_ClientManagement_getLandingData
	@ClientId INT
AS
BEGIN

	SELECT
		ServicePlanName = pp.Name,
		ServiceExpirationDescription = cc.ServicePlanExpirationDate

	FROM		ClientCompany CC
	
	INNER JOIN	PricingPlan PP
			ON	cc.CurrentPricingPlanId = pp.Id

END