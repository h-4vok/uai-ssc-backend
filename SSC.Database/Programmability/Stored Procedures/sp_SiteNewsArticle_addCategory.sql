CREATE PROCEDURE sp_SiteNewsArticle_addCategory
	@Id INT,
	@CategoryId INT
AS
BEGIN

	INSERT SiteNewsArticleCategory (
		SiteNewsArticleId,
		SiteNewsCategoryId
	)
	SELECT
		SiteNewsArticleId = @Id,
		SiteNewsCategoryId = @CategoryId

END