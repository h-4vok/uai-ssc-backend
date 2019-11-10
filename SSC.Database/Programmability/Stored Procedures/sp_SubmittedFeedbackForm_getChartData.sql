CREATE PROCEDURE sp_SubmittedFeedbackForm_getChartData
	@QuestionId INT
AS
BEGIN

	DECLARE @TotalCount INT

	SELECT
		@TotalCount = COUNT(1)

	FROM		SubmittedFeedbackFormAnswer sffa
		
	WHERE		sffa.FeedbackFormQuestionId = @QuestionId;

	WITH CTE_QuestionAnswerCounts AS
	(
		SELECT
			sc.Id,
			sc.ChoiceTitle,
			SurveyCount = COUNT(ss.Id)

		FROM		FeedbackFormQuestionChoice SC

		INNER JOIN	SubmittedFeedbackFormAnswer SS
				ON	sc.Id = ss.FeedbackFormQuestionChoiceId

		WHERE		sc.FeedbackFormQuestionId = @QuestionId

		GROUP BY
			sc.Id,
			sc.ChoiceTitle
	)
	SELECT 
		'Label' = scc.ChoiceTitle,
		'Percentage' = CASE WHEN @TotalCount = 0 THEN 0 ELSE CONVERT(NUMERIC(12, 2), (CONVERT(NUMERIC(12, 2), scc.SurveyCount) * 100) / @TotalCount) END,
		Count = scc.SurveyCount

	FROM		CTE_QuestionAnswerCounts SCC

END