CREATE PROCEDURE sp_PlatformMenuItem_create
	@PlatformMenuId INT,
	@MenuOrder INT,
	@RelativeRoute NVARCHAR(500),
	@TranslationKey NVARCHAR(500),
	@CreatedBy INT
AS
BEGIN

	INSERT PlatformMenuItem (
		PlatformMenuId,
		MenuOrder,
		RelativeRoute,
		TranslationKey,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		PlatformMenuId = @PlatformMenuId,
		MenuOrder = @MenuOrder,
		RelativeRoute = @RelativeRoute,
		TranslationKey = @TranslationKey,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END