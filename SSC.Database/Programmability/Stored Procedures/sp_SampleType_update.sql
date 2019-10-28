CREATE PROCEDURE sp_SampleType_update
	@Id INT,
	@Name NVARCHAR(500),
	@TenantId INT,
	@UpdatedBy INT
AS
BEGIN

	UPDATE
		SampleType
	
	SET
		Name = @Name,
		UpdatedBy = @UpdatedBy,
		UpdatedDate = GETUTCDATE()

	WHERE		Id = @Id
	AND			TenantId = @TenantId

END