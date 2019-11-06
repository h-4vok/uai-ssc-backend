CREATE PROCEDURE sp_FeedbackForm_getQuestions
	@Id INT
AS
BEGIN

	SELECT
		Id,
		Question

	FROM		FeedbackFormQuestion

	WHERE		FeedbackFormId = @Id

END