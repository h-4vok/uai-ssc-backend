CREATE PROCEDURE sp_SiteNewsCategory_create
	@Description NVARCHAR(100)
AS
BEGIN

	INSERT SiteNewsCategory (
		Description
	)
	SELECT
		Description = @Description 

END