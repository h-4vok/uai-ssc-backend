CREATE PROCEDURE sp_SubmittedFeedbackForm_create
	@FeedbackFormId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT SubmittedFeedbackForm (
		FeedbackFormId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		FeedbackFormId = @FeedbackFormId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END