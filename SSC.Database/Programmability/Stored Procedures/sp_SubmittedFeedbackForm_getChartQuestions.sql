CREATE PROCEDURE sp_SubmittedFeedbackForm_getChartQuestions
	@FeedbackFormId INT
AS
BEGIN

	SELECT
		QuestionId = ffq.Id,
		QuestionTitle = ffq.Question

	FROM		FeedbackForm FF

	INNER JOIN	FeedbackFormQuestion FFQ
			ON	ff.Id = ffq.FeedbackFormId

	WHERE		ff.Id = @FeedbackFormId

END