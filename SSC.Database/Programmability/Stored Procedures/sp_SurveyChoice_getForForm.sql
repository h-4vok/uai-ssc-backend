CREATE PROCEDURE sp_SurveyChoice_getForForm
	@Id INT
AS
BEGIN

	SELECT
		sc.Id,
		sc.ChoiceTitle

	FROM		SurveyChoice SC

	WHERE		sc.SurveyFormId = @Id

END