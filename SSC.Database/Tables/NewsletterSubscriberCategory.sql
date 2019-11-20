CREATE TABLE [dbo].[NewsletterSubscriberCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	NewsletterSubscriberId INT NOT NULL,
	SiteNewsCategoryId INT NOT NULL,

	FOREIGN KEY (NewsletterSubscriberId) REFERENCES NewsletterSubscriber,
	FOREIGN KEY (SiteNewsCategoryId) REFERENCES SiteNewsCategory
)
