CREATE PROCEDURE sp_FeedbackFormQuestionChoice_create
	@FeedbackFormQuestionId INT,
	@ChoiceTitle NVARCHAR(100),
	@CreatedBy INT
AS
BEGIN

	INSERT FeedbackFormQuestionChoice (
		FeedbackFormQuestionId,
		ChoiceTitle,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		FeedbackFormQuestionId = @FeedbackFormQuestionId,
		ChoiceTitle = @ChoiceTitle,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

END