CREATE PROCEDURE sp_SampleFunction_create
	@TenantId INT,
	@Code NVARCHAR(500),
	@Name NVARCHAR(500),
	@CreatedBy INT
AS
BEGIN

	INSERT SampleFunction (
		TenantId,
		Code,
		Name,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		TenantId = @TenantId,
		Code = @Code,
		Name = @Name,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

END