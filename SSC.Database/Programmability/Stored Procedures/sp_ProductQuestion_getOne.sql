CREATE PROCEDURE sp_ProductQuestion_getOne
	@Id INT
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

	WHERE		pq.Id = @Id

END