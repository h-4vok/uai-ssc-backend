﻿CREATE PROCEDURE sp_SiteNewsArtigle_getBetween
	@DateFrom SMALLDATETIME,
	@DateTo SMALLDATETIME
AS
BEGIN

	SELECT
		sna.Id,
		sna.Author,
		sna.Content,
		sna.PublicationDate,
		sna.Title,
		sna.ThumbnailPath,
		sna.ThumbnailRelativePath

	FROM		SiteNewsArticle SNA

	WHERE		sna.PublicationDate BETWEEN @DateFrom AND @DateTo

END