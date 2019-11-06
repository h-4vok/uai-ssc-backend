CREATE PROCEDURE sp_FeedbackFormQuestion_getChoices
	@Id INT
AS
BEGIN

	SELECT
		ffqc.Id,
		ffqc.ChoiceTitle

	FROM		FeedbackFormQuestionChoice FFQC

	WHERE		ffqc.FeedbackFormQuestionId = @Id

END