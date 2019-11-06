CREATE PROCEDURE sp_FeedbackForm_updateIsCurrent
	@Id INT,
	@IsCurrent BIT
AS
BEGIN

	IF(@IsCurrent = 1)
	BEGIN
		UPDATE FeedbackForm SET IsCurrent = 0 WHERE IsCurrent = 1
	END

	UPDATE
		FeedbackForm
	SET
		IsCurrent = @IsCurrent
	WHERE		Id = @Id

END