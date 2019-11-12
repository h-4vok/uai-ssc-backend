CREATE PROCEDURE sp_SiteNewsArticle_getLatest
	@LatestCount INT
AS
BEGIN

	SELECT TOP (@LatestCount)
		sna.Id,
		sna.Author,
		sna.Content,
		sna.PublicationDate,
		sna.Title

	FROM		SiteNewsArticle SNA

	WHERE		CONVERT(DATE, sna.PublicationDate) <= CONVERT(DATE, GETDATE())

	ORDER BY	sna.PublicationDate DESC

END