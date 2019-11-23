CREATE PROCEDURE sp_WorkOrder_getAll
AS
BEGIN

	SELECT
		wo.Id,
		wo.RequestDate,
		CreatedBy = pu.UserName,
		TypeDescription = 'Generar Alícuotas',
		QuantityOfParentSamples = ISNULL(COUNT(DISTINCT wops.Id), 0),
		QuantityOfExpectedChildSamples = ISNULL(COUNT(DISTINCT woes.Id), 0),
		StatusDescription = wos.Description,
		CurrentlyAssignedTo = pua.UserName,
		wo.UpdatedDate,
		UpdatedBy = puu.UserName

	FROM		WorkOrder WO

	INNER JOIN	PlatformUser PU
			ON	wo.CreatedBy = pu.Id

	INNER JOIN	PlatformUser PUU
			ON	wo.UpdatedBy = puu.Id

	INNER JOIN	WorkOrderParentSample WOPS
			ON	wo.Id = wops.WorkOrderId

	INNER JOIN	WorkOrderStatus WOS
			ON	wo.WorkOrderStatusId = wos.Id

	LEFT  JOIN	WorkOrderExpectedSample WOES
			ON	wo.Id = woes.WorkOrderId

	LEFT  JOIN	PlatformUser PUA
			ON	wo.CurrentlyAssignedUserId = pua.Id

	GROUP BY	
		wo.Id,
		wo.RequestDate,
		pu.UserName,
		wos.Description,
		pua.UserName,
		wo.UpdatedDate,
		puu.UserName

END