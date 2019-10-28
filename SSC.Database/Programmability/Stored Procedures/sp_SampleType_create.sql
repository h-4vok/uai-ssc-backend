CREATE PROCEDURE sp_SampleType_create
	@Name NVARCHAR(500),
	@TenantId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT SampleType (
		Name,
		TenantId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Name = @Name,
		TenantId = @TenantId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()
END