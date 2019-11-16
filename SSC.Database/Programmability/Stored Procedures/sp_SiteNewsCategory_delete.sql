CREATE PROCEDURE sp_SiteNewsCategory_delete
	@Id INT
AS
BEGIN

	DELETE SiteNewsCategory WHERE Id = @Id

END