CREATE PROCEDURE sp_SurveyChoice_create
	@ChoiceTitle NVARCHAR(100),
	@SurveyFormId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT SurveyChoice (
		ChoiceTitle,
		SurveyFormId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		ChoiceTitle = @ChoiceTitle,
		SurveyFormId = @SurveyFormId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

END