CREATE PROCEDURE sp_SiteNewsArticle_removeCategories
	@Id INT
AS
BEGIN

	DELETE
		SiteNewsArticleCategory
	WHERE	
		SiteNewsArticleId = @Id

END