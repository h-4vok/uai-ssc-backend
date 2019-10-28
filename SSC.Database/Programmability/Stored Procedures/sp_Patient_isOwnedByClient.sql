CREATE PROCEDURE sp_Patient_isOwnedByClient	
	@Id INT,
	@TenantId INT
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		Patient

	WHERE		Id = @Id
	AND			TenantId = @TenantId

END