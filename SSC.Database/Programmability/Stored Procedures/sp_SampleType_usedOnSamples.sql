CREATE PROCEDURE sp_SampleType_usedOnSamples
	@Id INT
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		SampleParameter SP

	WHERE		sp.ParameterTypeId = @Id

END