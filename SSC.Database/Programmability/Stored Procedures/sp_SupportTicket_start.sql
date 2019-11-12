CREATE PROCEDURE sp_SupportTicket_start
	@StatusCode NVARCHAR(100),
	@UserId INT,
	@Subject NVARCHAR(200)
AS
BEGIN

	INSERT SupportTicket (
		Subject,
		SupportTicketStatusId,
		UserId
	)
	SELECT
		Subject = @Subject,
		SupportTicketStatusId = sts.Id,
		UserId = @UserId

	FROM		SupportTicketStatus STS
	WHERE		sts.Code = @StatusCode

	SELECT SCOPE_IDENTITY()

END