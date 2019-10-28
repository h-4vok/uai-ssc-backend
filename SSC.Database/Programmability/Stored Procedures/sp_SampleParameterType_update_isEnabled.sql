CREATE PROCEDURE sp_SampleParameterType_update_isEnabled
	@Id INT,
	@IsEnabled BIT
AS
BEGIN

	UPDATE
		SampleTypeParameter

	SET
		IsEnabled = @IsEnabled

	WHERE
		Id = @Id

END