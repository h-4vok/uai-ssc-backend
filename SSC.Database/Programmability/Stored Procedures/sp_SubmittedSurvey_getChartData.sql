CREATE PROCEDURE sp_SubmittedSurvey_getChartData
	@SurveyFormId INT
AS
BEGIN

	DECLARE @TotalCount INT

	SELECT
		@TotalCount = COUNT(1)

	FROM		SubmittedSurvey SS
		
	WHERE		ss.SurveyFormId = @SurveyFormId;

	WITH CTE_SurveyChoiceCounts AS
	(
		SELECT
			sc.Id,
			sc.ChoiceTitle,
			SurveyCount = COUNT(ss.Id)

		FROM		SurveyChoice SC

		INNER JOIN	SubmittedSurvey SS
				ON	sc.Id = ss.SurveyChoiceId

		WHERE		sc.SurveyFormId = @SurveyFormId
		AND			ss.SurveyFormId = @SurveyFormId

		GROUP BY
			sc.Id,
			sc.ChoiceTitle
	)
	SELECT 
		'Label' = scc.ChoiceTitle,
		'Data' = CONVERT(NUMERIC(12, 2), (CONVERT(NUMERIC(12, 2), scc.SurveyCount) * 100) / @TotalCount)

	FROM		CTE_SurveyChoiceCounts SCC

END