CREATE PROCEDURE sp_SampleFunction_get
	@TenantId INT,
	@Id INT
AS
BEGIN

	SELECT
		sf.Id,
		sf.Code,
		sf.Name,
		ClientCompanyId = cc.Id,
		ClientCompanyName = cc.Name,
		sf.IsEnabled

	FROM		SampleFunction SF

	INNER JOIN	ClientCompany CC
			ON	sf.TenantId = cc.Id

	WHERE
		sf.TenantId = @TenantId
	AND	sf.Id = @Id

END