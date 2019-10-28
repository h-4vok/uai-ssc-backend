CREATE PROCEDURE sp_Patient_GetAll
	@TenantId INT
AS
BEGIN

	SELECT
		p.Id,
		p.Name,
		PatientTypeDescription = pt.Description,
		QuantityOfAvailableSamples = 0, -- TODO: Quantities are pending
		QuantityOfUsedSamples = 0

	FROM		Patient P

	INNER JOIN	PatientType PT
			ON	p.PatientTypeId = pt.Id


	WHERE		p.TenantId = @TenantId

END