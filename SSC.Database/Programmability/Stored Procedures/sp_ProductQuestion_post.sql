CREATE PROCEDURE sp_ProductQuestion_post
	@QuestionBy NVARCHAR(100),
	@Question NVARCHAR(500),
	@PricingPlanCode NVARCHAR(100)
AS
BEGIN

	INSERT ProductQuestion (
		Question,
		QuestionBy,
		PricingPlanId
	)
	SELECT
		Question = @Question,
		QuestionBy = @QuestionBy,
		PricingPlan = pp.Id

	FROM		PricingPlan PP
	WHERE		pp.Code = @PricingPlanCode

END