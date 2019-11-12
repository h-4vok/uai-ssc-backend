CREATE PROCEDURE sp_SiteNewsArticle_delete
	@Id INT
AS
BEGIN

	DELETE SiteNewsArticle WHERE Id = @Id

END