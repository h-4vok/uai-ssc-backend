CREATE PROCEDURE sp_SampleTypeParameter_getBySampleType
	@SampleTypeId INT
AS
BEGIN

	SELECT
		stp.Id,
		stp.Code,
		stp.DefaultDescription,
		ParameterDataTypeId = pdt.Id,
		ParameterDataTypeCode = pdt.Code,
		stp.DecimalDigits,
		stp.MinimumRange,
		stp.MaximumRange,
		UnitOfMeasureId = uom.Id,
		UnitOfMeasureCode = uom.Code,
		stp.IsEnabled

	FROM		SampleTypeParameter STP

	INNER JOIN	SampleTypeToParameter STTP
			ON	stp.Id = sttp.ParameterTypeId

	INNER JOIN	SampleType ST
			ON	sttp.SampleTypeId = st.Id
		
	LEFT  JOIN	ParameterDataType PDT
			ON	stp.ParameterDataTypeId = pdt.Id

	LEFT  JOIN	UnitOfMeasure UOM
			ON	stp.UnitOfMeasureId = uom.Id

	WHERE		st.Id = @SampleTypeId

END