CREATE PROCEDURE sp_PricingPlanComment_get
	@PricingPlanCode NVARCHAR(200)
AS
BEGIN

	SELECT
		Id,
		Comment,
		CommentBy,
		PricingPlanId,
		Rating,
		CreatedBy,
		CreatedDate

	FROM		PricingPlanComment 

END