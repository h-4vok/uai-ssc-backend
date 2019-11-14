CREATE PROCEDURE sp_ClientCompany_updateIsEnabled
	@Id INT,
	@IsEnabled BIT, 
	@UpdatedBy INT
AS
BEGIN

	UPDATE
		ClientCompany

	SET
		IsEnabled = @IsEnabled,
		UpdatedBy = @UpdatedBy,
		UpdatedDate = GETUTCDATE()

	WHERE
		Id = @Id

END