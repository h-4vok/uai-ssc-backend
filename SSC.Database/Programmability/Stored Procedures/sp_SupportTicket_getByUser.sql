﻿CREATE PROCEDURE sp_SupportTicket_getByUser
	@UserId INT
AS
BEGIN

	SELECT
		st.Id,
		st.Subject,
		st.UserId,
		'StatusId' = stt.Id,
		'StatusCode' = stt.Code,
		'StatusTranslationKey' = stt.TranslationKey

	FROM		SupportTicket ST

	INNER JOIN	SupportTicketStatus STT
			ON	st.SupportTicketStatusId = stt.Id
	
	WHERE		st.UserId = @UserId

END