CREATE PROCEDURE sp_FeedbackFormQuestion_create
	@FeedbackFormId INT,
	@Question NVARCHAR(500),
	@CreatedBy INT
AS
BEGIN

	INSERT FeedbackFormQuestion (
		FeedbackFormId,
		Question,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		FeedbackFormId = @FeedbackFormId,
		Question = @Question,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END