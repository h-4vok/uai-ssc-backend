
CREATE PROCEDURE sp_SiteNewsArticle_getAll
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

END