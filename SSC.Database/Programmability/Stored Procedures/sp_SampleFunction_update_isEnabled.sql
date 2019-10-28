CREATE PROCEDURE sp_SampleFunction_update_isEnabled
	@TenantId INT,
	@Id INT,
	@IsEnabled BIT
AS
BEGIN

	UPDATE
		SampleFunction

	SET
		IsEnabled = @IsEnabled

	WHERE
		TenantId = @TenantId
	AND	Id = @Id

END