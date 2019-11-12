CREATE PROCEDURE sp_SupportTicketConversation_add
	@SupportTicketId INT,
	@AuthorId INT,
	@Content NVARCHAR(MAX)
AS
BEGIN

	INSERT SupportTicketConversation (
		AuthorId,
		SupportTicketId,
		Content
	)
	SELECT
		AuthorId = @AuthorId,
		SupportTicketId = @SupportTicketId,
		Content = @Content

END