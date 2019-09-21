CREATE PROCEDURE sp_ClientCompany_create
	@Name NVARCHAR(200),
	@CurrentPricingPlanId INT,
	@ApiToken NVARCHAR(500)
AS
BEGIN

	INSERT ClientCompany ( Name, CurrentPricingPlanId, ApiToken, CreatedDate, UpdatedDate )
	SELECT
		Name = @Name, 
		CurrentPricingPlanId = @CurrentPricingPlanId, 
		ApiToken = @ApiToken,
		CreatedDate = GETUTCDATE(),
		UpdatedDate = GETUTCDATE()

	SELECT SCOPE_IDENTITY()

END