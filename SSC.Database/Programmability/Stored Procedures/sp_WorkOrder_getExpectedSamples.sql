CREATE PROCEDURE sp_WorkOrder_getExpectedSamples
	@WorkOrderId INT
AS
BEGIN

	SELECT
		ParentSampleId = s.Id,
		DilutionFactor = woes.DilutionFactor,
		ParentBarcode = s.Barcode,
		ResultingVolume = woes.ResultingVolume,
		UnitOfMeasureCode = uom.Code,
		VolumeToUse = woes.VolumeToUse

	FROM		WorkOrderExpectedSample WOES

	INNER JOIN	Sample S
			ON	woes.ParentSampleId = s.Id

	INNER JOIN	WorkOrderParentSample WOPS
			ON	woes.ParentSampleId = wops.SampleId

	INNER JOIN	UnitOfMeasure UOM
			ON	s.UnitOfMeasureId = uom.Id

	WHERE		woes.WorkOrderId = @WorkOrderId
	AND			wops.Checked = 1
	AND			wops.WorkOrderId = @WorkOrderId

END