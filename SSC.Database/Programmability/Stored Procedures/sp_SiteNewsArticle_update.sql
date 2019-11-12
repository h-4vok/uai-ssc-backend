CREATE PROCEDURE sp_SiteNewsArticle_update
	@Author NVARCHAR(500),
	@Id INT,
	@Title NVARCHAR(500),
	@Content NVARCHAR(500),
	@PublicationDate SMALLDATETIME,
	@UpdatedBy INT
AS
BEGIN

	UPDATE
		SiteNewsArticle

	SET
		Author = @Author,
		Title = @Title,
		Content = @Content,
		PublicationDate = @PublicationDate,
		UpdatedBy = @UpdatedBy,
		UpdatedDate = GETUTCDATE()

	WHERE
		Id = @Id

END