CREATE PROCEDURE sp_FeedbackForm_get
AS
BEGIN
	
	SELECT
		ff.Id,
		ff.IsCurrent,
		ff.CreatedDate

	FROM		FeedbackForm FF

END