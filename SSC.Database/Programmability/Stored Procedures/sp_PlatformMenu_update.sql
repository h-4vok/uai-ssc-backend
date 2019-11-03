CREATE PROCEDURE sp_PlatformMenu_update
	@Code NVARCHAR(100),
	@TranslationKey NVARCHAR(500),
	@MenuOrder INT,
	@Id INT,
	@UpdatedBy INT
AS
BEGIN

	
	UPDATE
		PlatformMenu

	SET
		Code = @Code,
		TranslationKey = @TranslationKey,
		MenuOrder = @MenuOrder,
		UpdatedBy = @UpdatedBy,
		UpdatedDate = GETUTCDATE()

	WHERE		Id = @Id


END