CREATE PROCEDURE sp_SiteNewsArticle_getAll
AS
BEGIN

	SELECT
		sna.Id,
		sna.Author,
		sna.Content,
		sna.PublicationDate,
		sna.Title

	FROM		SiteNewsArticle SNA

END