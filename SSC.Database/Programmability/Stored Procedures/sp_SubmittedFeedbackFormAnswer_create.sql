CREATE PROCEDURE sp_SubmittedFeedbackFormAnswer_create
	@SubmittedFeedbackFormId INT,
	@FeedbackFormQuestionId INT,
	@FeedbackFormQuestionChoiceId INT,
	@CreatedBy INT
AS
BEGIN

	INSERT SubmittedFeedbackFormAnswer (
		SubmittedFeedbackFormId,
		FeedbackFormQuestionId,
		FeedbackFormQuestionChoiceId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		SubmittedFeedbackFormId = @SubmittedFeedbackFormId,
		FeedbackFormQuestionId = @FeedbackFormQuestionId,
		FeedbackFormQuestionChoiceId = @FeedbackFormQuestionChoiceId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

END