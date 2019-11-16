CREATE PROCEDURE sp_SiteNewsCategory_isInUse
	@Id INT
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		SiteNewsArticleCategory

	WHERE		SiteNewsCategoryId = @Id

END