CREATE PROCEDURE sp_QueuedMail_create
	@MailTo NVARCHAR(1500),
	@Subject NVARCHAR(500),
	@Body NVARCHAR(MAX)
AS
BEGIN

	INSERT QueuedMail (
		MailTo,
		Subject,
		Body,
		QueuedDate,
		ToPublishDate
	)
	SELECT
		MailTo = @MailTo,
		Subject = @Subject,
		Body = @Body,
		QueuedDate = GETUTCDATE(),
		ToPublishDate = GETUTCDATE()

END