CREATE PROCEDURE sp_SurveyForm_create
	@QuestionTitle NVARCHAR(500),
	@CreatedBy INT
AS
BEGIN

	INSERT SurveyForm (
		QuestionTitle,
		IsEnabled,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		QuestionTitle = @QuestionTitle,
		IsEnabled = 0,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END