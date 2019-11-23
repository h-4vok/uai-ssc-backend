CREATE PROCEDURE [dbo].[sp_testData_createSamples]
AS
BEGIN

	INSERT Sample (
		Barcode,
		SampleTypeId,
		SampleFunctionId,
		InitialVolume,
		CurrentVolume,
		UnitOfMeasureId,
		StatusCode,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Barcode = CONCAT('TEST', '000', 'ST', CONVERT(NVARCHAR(10), st.Id), 'SF', CONVERT(NVARCHAR(10), sf.Id), 'UOM', CONVERT(NVARCHAR(10), uom.Id)),
		SampleTypeId = st.Id,
		SampleFunctionId = sf.Id,
		InitialVolume = 100,
		CurrentVolume = 100,
		UnitOfMeasureId = uom.Id,
		StatusCode = 'available',
		CreatedBy = 1,
		UpdatedBy = 1

	FROM		SampleFunction SF
	CROSS JOIN	SampleType ST
	CROSS JOIN	UnitOfMeasure UOM

END