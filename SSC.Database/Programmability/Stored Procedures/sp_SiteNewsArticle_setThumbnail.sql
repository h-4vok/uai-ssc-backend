CREATE PROCEDURE sp_SiteNewsArticle_setThumbnail
	@Id INT,
	@ThumbnailPath NVARCHAR(500),
	@ThumbnailRelativePath NVARCHAR(500)
AS
BEGIN

	UPDATE
		SiteNewsArticle

	SET
		ThumbnailPath = @ThumbnailPath,
		ThumbnailRelativePath = @ThumbnailRelativePath

	WHERE
		Id = @Id

END