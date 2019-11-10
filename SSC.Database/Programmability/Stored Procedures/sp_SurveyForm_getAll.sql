CREATE PROCEDURE sp_SurveyForm_getAll
AS
BEGIN
	
	SELECT
		sf.Id,
		sf.QuestionTitle,
		sf.IsEnabled

	FROM		SurveyForm SF

END