CREATE PROCEDURE sp_FeedbackForm_create
	@IsCurrent BIT,
	@CreatedBy INT
AS
BEGIN

	IF(@IsCurrent = CONVERT(BIT, 1))
	BEGIN
		UPDATE FeedbackForm SET IsCurrent = 0, UpdatedBy = @CreatedBy, UpdatedDate = GETUTCDATE() WHERE IsCurrent = 1
	END

	INSERT FeedbackForm (
		IsCurrent,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		IsCurrent = @IsCurrent,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END