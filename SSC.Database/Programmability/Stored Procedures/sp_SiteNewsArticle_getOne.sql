CREATE PROCEDURE sp_SiteNewsArticle_getOne
	@Id INT
AS
BEGIN

	SELECT
		sna.Id,
		sna.Author,
		sna.Content,
		sna.PublicationDate,
		sna.Title

	FROM		SiteNewsArticle SNA

	WHERE		sna.Id = @Id

END