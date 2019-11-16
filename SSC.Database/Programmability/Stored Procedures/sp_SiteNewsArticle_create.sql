CREATE PROCEDURE sp_SiteNewsArticle_create
	@Author NVARCHAR(500),
	@Title NVARCHAR(500),
	@Content NVARCHAR(MAX),
	@PublicationDate SMALLDATETIME,
	@CreatedBy INT
AS
BEGIN

	INSERT SiteNewsArticle (
		Author,
		Title,
		Content,
		PublicationDate,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Author = @Author,
		Title = @Title,
		Content = @Content,
		PublicationDate = @PublicationDate,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	SELECT SCOPE_IDENTITY()

END