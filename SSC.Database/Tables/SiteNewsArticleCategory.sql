CREATE TABLE [dbo].[SiteNewsArticleCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SiteNewsCategoryId INT NOT NULL,
	SiteNewsArticleId INT NOT NULL,

	FOREIGN KEY (SiteNewsCategoryId) REFERENCES SiteNewsCategory,
	FOREIGN KEY (SiteNewsArticleId) REFERENCES SiteNewsArticle
)
