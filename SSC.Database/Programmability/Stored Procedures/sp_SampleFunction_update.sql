CREATE PROCEDURE sp_SampleFunction_update
	@TenantId INT,
	@Id INT,
	@Code NVARCHAR(500),
	@Name NVARCHAR(500),
	@UpdatedBy INT
AS
BEGIN

	UPDATE
		SampleFunction

	SET
		Code = @Code,
		Name = @Name,
		UpdatedBy = @UpdatedBy

	WHERE	
		TenantId = @TenantId
	AND	Id = @Id

END