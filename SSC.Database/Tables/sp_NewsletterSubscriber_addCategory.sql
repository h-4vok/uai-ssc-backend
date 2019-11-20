CREATE PROCEDURE sp_NewsletterSubscriber_addCategory
	@NewsletterSubscriberId INT,
	@SiteNewsCategoryId INT
AS
BEGIN

	INSERT NewsletterSubscriberCategory (
		NewsletterSubscriberId,
		SiteNewsCategoryId
	)
	SELECT
		NewsletterSubscriberId = @NewsletterSubscriberId,
		SiteNewsCategoryId = @SiteNewsCategoryId

END