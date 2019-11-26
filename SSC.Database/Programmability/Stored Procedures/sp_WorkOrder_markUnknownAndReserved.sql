CREATE PROCEDURE sp_WorkOrder_markUnknownAndReserved
	@WorkOrderId INT
AS
BEGIN

	UPDATE
		TBU

	SET
		StatusCode = CASE WHEN wops.Checked = 1 THEN 'reserved' ELSE 'unknown' END

	FROM		Sample TBU

	INNER JOIN	WorkOrderParentSample WOPS
			ON	tbu.Id = wops.SampleId

	WHERE		Wops.WorkOrderId = @WorkOrderId

END