CREATE PROCEDURE sp_SupportTicketConversation_getByTicket
	@Id INT
AS
BEGIN

	SELECT
		STC.Id,
		stc.AuthorId,
		stc.Content,
		stc.SupportTicketId,
		'AuthorName' = pu.UserName

	FROM		SupportTicketConversation STC

	INNER JOIN	PlatformUser PU		
			ON	stc.AuthorId = pu.Id

	WHERE		stc.SupportTicketId = @Id

END