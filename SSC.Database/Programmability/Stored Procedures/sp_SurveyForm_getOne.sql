CREATE PROCEDURE sp_SurveyForm_getOne
	@Id INT
AS
BEGIN

	SELECT
		sf.Id,
		sf.QuestionTitle,
		sf.ExpirationDate,
		sf.IsEnabled

	FROM		SurveyForm SF

	WHERE		sf.Id = @Id

END