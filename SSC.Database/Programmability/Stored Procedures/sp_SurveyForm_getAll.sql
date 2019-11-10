CREATE PROCEDURE sp_SurveyForm_getAll
AS
BEGIN
	
	SELECT
		sf.Id,
		sf.QuestionTitle,
		sf.ExpirationDate,
		sf.IsEnabled

	FROM		SurveyForm SF

END