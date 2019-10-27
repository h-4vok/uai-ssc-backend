CREATE PROCEDURE sp_UnitOfMeasure_update_isEnabled
	@Id INT,
	@IsEnabled BIT
AS
BEGIN

	UPDATE
		UnitOfMeasure
	SET
		IsEnabled = @IsEnabled
	WHERE
		Id = @Id

END