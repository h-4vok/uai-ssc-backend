CREATE PROCEDURE sp_FeedbackForm_getOne
	@Id INT
AS
BEGIN

	SELECT
		Id,
		IsCurrent

	FROM		FeedbackForm

	WHERE		Id = @Id

END