CREATE PROCEDURE sp_SupportTicket_updateStatus
	@TicketId INT,
	@StatusCode NVARCHAR(100)
AS
BEGIN

	DECLARE @StatusId INT

	SELECT @StatusId = Id FROM SupportTicketStatus WHERE Code = @StatusCode

	UPDATE
		SupportTicket

	SET
		SupportTicketStatusId = @StatusId

	WHERE		Id = @TicketId

END