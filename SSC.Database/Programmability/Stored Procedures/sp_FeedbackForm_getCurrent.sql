CREATE PROCEDURE sp_FeedbackForm_getCurrent
AS
BEGIN

	SELECT TOP 1 Id FROM FeedbackForm
	WHERE IsCurrent = 1
	
END