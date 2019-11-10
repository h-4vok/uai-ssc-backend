CREATE PROCEDURE sp_SurveyForm_create
	@QuestionTitle NVARCHAR(500),
	@ExpirationDate SMALLDATETIME,
	@CreatedBy INT
AS
BEGIN

	INSERT SurveyForm (
		QuestionTitle,
		ExpirationDate,
		IsEnabled,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		QuestionTitle = @QuestionTitle,
		ExpirationDate = @ExpirationDate,
		IsEnabled = 0,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END