CREATE PROCEDURE sp_FeedbackForm_get
AS
BEGIN
	
	SELECT
		ff.Id,
		ff.IsCurrent

	FROM		FeedbackForm FF

END