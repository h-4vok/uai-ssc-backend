CREATE PROCEDURE sp_Role_updateIsEnabled
	@Id INT,
	@IsEnabled BIT,
	@UpdatedBy INT
AS
BEGIN

	UPDATE
		[Role]

	SET
		IsEnabled		= @IsEnabled,
		UpdatedBy		= @UpdatedBy

	WHERE
		Id = @Id

END