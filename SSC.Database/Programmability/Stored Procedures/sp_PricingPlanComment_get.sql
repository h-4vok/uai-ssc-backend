CREATE PROCEDURE sp_PricingPlanComment_get
	@PricingPlanCode NVARCHAR(200)
AS
BEGIN

	SELECT
		ppc.Id,
		ppc.Comment,
		ppc.CommentBy,
		ppc.PricingPlanId,
		ppc.Rating,
		ppc.CreatedBy,
		ppc.CreatedDate

	FROM		PricingPlanComment PPC

	INNER JOIN	PricingPlan PP
			ON	PPC.PricingPlanId = PP.Id

	WHERE		pp.Code = @PricingPlanCode

END