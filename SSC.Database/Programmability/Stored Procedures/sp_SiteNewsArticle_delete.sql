CREATE PROCEDURE sp_SiteNewsArticle_delete
	@Id INT
AS
BEGIN

	DELETE SiteNewsArticleCategory WHERE SiteNewsArticleId = @Id
	DELETE SiteNewsArticle WHERE Id = @Id

END