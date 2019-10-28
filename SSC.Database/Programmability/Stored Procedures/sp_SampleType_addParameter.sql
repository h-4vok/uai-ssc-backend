CREATE PROCEDURE sp_SampleType_addParameter
	@Id INT,
	@SampleTypeParameterId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT SampleTypeToParameter (
		SampleTypeId,
		ParameterTypeId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		SampleTypeId = @Id,
		ParameterTypeId = @SampleTypeParameterId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

END