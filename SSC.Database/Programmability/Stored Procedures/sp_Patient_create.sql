CREATE PROCEDURE sp_Patient_create	
	@PatientTypeId INT,
	@Name NVARCHAR(500),
	@TenantId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT Patient (
		PatientTypeId,
		Name,
		TenantId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		PatientTypeId = @PatientTypeId,
		Name = @Name,
		TenantId = @TenantId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

END