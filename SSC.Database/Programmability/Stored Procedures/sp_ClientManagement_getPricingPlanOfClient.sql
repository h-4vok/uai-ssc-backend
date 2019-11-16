CREATE PROCEDURE sp_ClientManagement_getPricingPlanOfClient
	@ClientId INT
AS
BEGIN
	
	SELECT
		Code = pp.Code,
		Price = pp.Price,
		AnualDiscountPercentage = pp.AnualDiscountPercentage

	FROM		ClientCompany CC

	INNER JOIN	PricingPlan PP
			ON	cc.CurrentPricingPlanId = pp.Id

	WHERE		cc.Id = @ClientId

END