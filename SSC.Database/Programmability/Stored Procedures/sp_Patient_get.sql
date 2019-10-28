CREATE PROCEDURE sp_Patient_get	
	@Id INT
AS
BEGIN

	SELECT
		p.Id,
		p.Name,
		PatientTypeId = pt.Id,
		PatientTypeCode = pt.Code,
		PatienTypeDescription = pt.Description,
		ClientCompanyId = cc.Id,
		ClientCompanyName = cc.Name


	FROM		Patient P

	INNER JOIN	PatientType PT
			ON	p.PatientTypeId = pt.Id

	INNER JOIN	ClientCompany CC
			ON	p.TenantId = cc.Id


	WHERE		p.Id = @Id

END