CREATE PROCEDURE sp_Patient_update
	@PatientTypeId INT,
	@Name NVARCHAR(500),
	@TenantId INT,
	@Id INT,
	@UpdatedBy INT
AS
BEGIN

	UPDATE
		Patient

	SET
		PatientTypeId = @PatientTypeId,
		Name = @Name,
		UpdatedBy = @UpdatedBy,
		UpdatedDate = GETUTCDATE()

	WHERE		Id = @Id
	AND			TenantId = @TenantId
		

END