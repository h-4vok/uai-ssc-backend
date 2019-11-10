CREATE PROCEDURE sp_SurveyForm_updateIsEnabled
	@Id INT,
	@IsEnabled BIT
AS
BEGIN

	UPDATE
		SurveyForm

	SET
		IsEnabled = @IsEnabled

	WHERE
		Id = @Id

END