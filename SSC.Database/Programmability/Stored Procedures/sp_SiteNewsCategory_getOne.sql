CREATE PROCEDURE sp_SiteNewsCategory_getOne
	@Id INT
AS
BEGIN

	SELECT
		Id,
		Description

	FROM		SiteNewsCategory

	WHERE		Id = @Id

END