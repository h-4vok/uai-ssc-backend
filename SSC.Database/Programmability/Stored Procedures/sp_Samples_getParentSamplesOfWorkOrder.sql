CREATE PROCEDURE sp_Samples_getParentSamplesOfWorkOrder
	@WorkOrderId INT
AS
BEGIN

	SELECT
		s.Id,
		s.Barcode,
		SampleTypeCode = st.Name,
		AvailableVolume = s.CurrentVolume,
		UnitOfMeasureCode = uom.Code

	FROM		Sample S

	INNER JOIN	SampleType ST
			ON	s.SampleTypeId = st.Id

	INNER JOIN	UnitOfMeasure UOM
			ON	s.UnitOfMeasureId = uom.Id

	INNER JOIN	WorkOrderParentSample WOPS
			ON	s.Id = wops.SampleId

	WHERE		wops.WorkOrderId = @WorkOrderId

END