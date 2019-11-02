CREATE PROCEDURE sp_PricingPlanComment_create
	@CreatedBy INT,
	@Comment NVARCHAR(500),
	@Rating INT,
	@CommentBy NVARCHAR(200)
AS
BEGIN
	
	-- Find the users pricing plan
	DECLARE @PricingPlanId INT

	SELECT
		@PricingPlanId = cc.CurrentPricingPlanId

	FROM		PlatformUser PU

	INNER JOIN	ClientCompany CC
			ON	pu.ClientId = cc.Id

	WHERE		pu.Id = @CreatedBy

	-- Insert the pricing plan comment
	INSERT PricingPlanComment (
		Rating,
		CreatedBy,
		UpdatedBy,
		Comment,
		CommentBy,
		PricingPlanId
	)
	SELECT
		Rating = @Rating,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy,
		Comment = @Comment,
		CommentBy = @CommentBy,
		PricingPlanId = @PricingPlanId

END