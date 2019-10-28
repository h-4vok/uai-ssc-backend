CREATE PROCEDURE sp_SampleTypeParameter_getAll
AS
BEGIN

	SELECT
		stp.Id,
		stp.Code,
		Description = stp.DefaultDescription,
		DataTypeName = pdt.Code,
		stp.MinimumRange,
		stp.MaximumRange,
		stp.DecimalDigits,
		stp.UpdatedDate,
		UpdatedBy = pu.UserName,
		stp.IsEnabled

	FROM		SampleTypeParameter STP

	INNER JOIN	ParameterDataType PDT
			ON	stp.ParameterDataTypeId = pdt.Id

	LEFT  JOIN	PlatformUser PU
			ON	stp.UpdatedBy = pu.Id

END