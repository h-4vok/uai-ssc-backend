CREATE PROCEDURE sp_SubmittedSurvey_create
	@SurveyFormId INT,
	@SurveyChoiceId INT
AS
BEGIN

	INSERT SubmittedSurvey (
		SurveyFormId,
		SurveyChoiceId
	)
	SELECT
		SurveyFormId = @SurveyFormId,
		SurveyChoiceId = @SurveyChoiceId

END