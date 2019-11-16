CREATE PROCEDURE sp_SiteNewsCategory_update
	@Id INT,
	@Description NVARCHAR(100)
AS
BEGIN

	UPDATE
		SiteNewsCategory

	SET
		Description = @Description

	WHERE
		Id = @Id

END