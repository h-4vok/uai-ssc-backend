CREATE PROCEDURE sp_SubmittedFeedbackForm_hasUserSubmittedCurrent
	@UserId INT
AS
BEGIN

	-- Check if we have any form that is active
	DECLARE @CurrentFormId INT

	SELECT
		@CurrentFormId = Id

	FROM		FeedbackForm FF
	WHERE		ff.IsCurrent = 1

	-- If we have no form, then we give the user a pass
	IF (@CurrentFormId IS NULL)
	BEGIN
		SELECT CONVERT(BIT, 1)
		RETURN
	END

	-- Return true if the user has submitted the form already
	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		FeedbackForm FF

	INNER JOIN	SubmittedFeedbackForm SFF
			ON	ff.Id = sff.FeedbackFormId

	WHERE		ff.IsCurrent = 1
	AND			sff.CreatedBy = @UserId

END