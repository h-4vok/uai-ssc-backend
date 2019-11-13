CREATE PROCEDURE sp_SupportTicket_getAll
AS
BEGIN

	SELECT
		st.Id,
		st.Subject,
		st.UserId,
		st.CreatedDate,
		'StatusId' = stt.Id,
		'StatusCode' = stt.Code,
		'StatusTranslationKey' = stt.TranslationKey

	FROM		SupportTicket ST

	INNER JOIN	SupportTicketStatus STT
			ON	st.SupportTicketStatusId = stt.Id

END