
CREATE PROCEDURE sp_SampleTypeParameter_update
	@Id INT,
	@Code NVARCHAR(500),
	@ParameterDataTypeId INT,
	@DecimalDigits INT,
	@MinimumRange NUMERIC(10, 2),
	@MaximumRange NUMERIC(10, 2),
	@UnitOfMeasureId INT,
	@UpdatedBy INT
AS
BEGIN

	UPDATE
		SampleTypeParameter

	SET
		Code = @Code,
		ParameterDataTypeId = @ParameterDataTypeId,
		DecimalDigits = @DecimalDigits,
		MinimumRange = @MinimumRange,
		MaximumRange = @MaximumRange,
		UnitOfMeasureId = @UnitOfMeasureId,
		UpdatedBy = @UpdatedBy,
		UpdatedDate = GETUTCDATE()

	WHERE
		Id = @Id

END