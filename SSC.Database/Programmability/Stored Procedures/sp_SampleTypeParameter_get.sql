CREATE PROCEDURE sp_SampleTypeParameter_get
	@Id INT
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

	LEFT  JOIN	ParameterDataType PDT
			ON	stp.ParameterDataTypeId = pdt.Id

	LEFT  JOIN	UnitOfMeasure UOM
			ON	stp.UnitOfMeasureId = uom.Id

	WHERE		stp.Id = @Id

END