CREATE PROCEDURE sp_PricingPlanComment_getByUser
	@CreatedBy INT
AS
BEGIN

	SELECT TOP 1
		Comment

	FROM		PricingPlanComment

	WHERE		CreatedBy = @CreatedBy

	ORDER BY	
		CreatedDate DESC

END