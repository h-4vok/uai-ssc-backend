CREATE PROCEDURE sp_PlatformMenu_create
	@Code NVARCHAR(100),
	@TranslationKey NVARCHAR(500),
	@MenuOrder INT,
	@CreatedBy INT
AS
BEGIN

	INSERT PlatformMenu (
		Code,
		TranslationKey,
		MenuOrder,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Code = @Code,
		TranslationKey = @TranslationKey,
		MenuOrder = @MenuOrder,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END