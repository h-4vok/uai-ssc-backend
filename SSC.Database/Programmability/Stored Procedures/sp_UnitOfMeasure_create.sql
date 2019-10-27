CREATE PROCEDURE sp_UnitOfMeasure_create
	@Code NVARCHAR(10),
	@DefaultDescription NVARCHAR(300),
	@CreatedBy INT
AS
BEGIN

	INSERT UnitOfMeasure (
		Code,
		DefaultDescription,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Code = @Code,
		DefaultDescription = @DefaultDescription,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	-- Insert translation key
	DECLARE @key NVARCHAR(300)
	SET @key = CONCAT('configuration.unit-of-measure.description[', @Code, ']')
	
	EXEC sp_SystemLanguageEntry_addOrUpdate
		@k = @key,
		@es = @DefaultDescription,
		@en = @DefaultDescription

END