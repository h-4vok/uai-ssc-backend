CREATE PROCEDURE sp_NewsletterSubscriber_getCategoriesOf
	@NewsletterSubscriberId INT
AS
BEGIN

	SELECT
		CategoryId = snc.Id,
		CategoryDescription = snc.Description

	FROM		SiteNewsCategory SNC

	INNER JOIN	NewsletterSubscriberCategory NSC
			ON	snc.Id = nsc.SiteNewsCategoryId

	WHERE		nsc.NewsletterSubscriberId = @NewsletterSubscriberId

END