CREATE PROCEDURE sp_ProductQuestion_getForProduct
	@PricingPlanCode NVARCHAR(100)
AS
BEGIN

	SELECT
		pq.Id,
		pq.PostedDate,
		pq.Question,
		pq.QuestionBy,
		pq.RepliedDate,
		pq.Reply,
		pq.ReplyBy,
		ReplyByDescription = pu.UserName,
		pq.PricingPlanId,
		PricingPlanName = pp.Name,
		PricingPlanCode = pp.Code

	FROM		ProductQuestion PQ

	INNER JOIN	PricingPlan PP
			ON	pq.PricingPlanId = pp.Id

	LEFT  JOIN	PlatformUser PU	
			ON	pq.ReplyBy = pu.Id

	WHERE		pp.Code = @PricingPlanCode

	ORDER BY	pq.PostedDate DESC

END