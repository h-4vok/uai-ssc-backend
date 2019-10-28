CREATE PROCEDURE sp_SampleTypeParameter_create
	@Code NVARCHAR(500),
	@DefaultDescription NVARCHAR(500),
	@ParameterDataTypeId INT,
	@DecimalDigits INT,
	@MinimumRange NUMERIC(10, 2),
	@MaximumRange NUMERIC(10, 2),
	@UnitOfMeasureId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT SampleTypeParameter (
		Code,
		DefaultDescription,
		ParameterDataTypeId,
		DecimalDigits,
		MinimumRange,
		MaximumRange,
		UnitOfMeasureId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Code = @Code,
		DefaultDescription = @DefaultDescription,
		ParameterDataTypeId = @ParameterDataTypeId,
		DecimalDigits = @DecimalDigits,
		MinimumRange = @MinimumRange,
		MaximumRange = @MaximumRange,
		UnitOfMeasureId = @UnitOfMeasureId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	-- Generate Translation Key
	DECLARE @key NVARCHAR(300)
	SET @key = CONCAT('configuration.sample-type-parameter.description[', @Code, ']')
	
	EXEC sp_SystemLanguageEntry_addOrUpdate
		@k = @key,
		@es = @DefaultDescription,
		@en = @DefaultDescription

END