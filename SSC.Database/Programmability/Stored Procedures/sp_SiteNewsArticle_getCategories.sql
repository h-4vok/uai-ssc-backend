CREATE PROCEDURE sp_SiteNewsArticle_getCategories
	@Id INT
AS
BEGIN

	SELECT
		CategoryId = snc.Id,
		CategoryDescription = snc.Description

	FROM		SiteNewsArticleCategory SNAC
	
	INNER JOIN	SiteNewsCategory SNC
			ON	snac.SiteNewsCategoryId = snc.Id

	WHERE		snac.SiteNewsArticleId = @Id

END