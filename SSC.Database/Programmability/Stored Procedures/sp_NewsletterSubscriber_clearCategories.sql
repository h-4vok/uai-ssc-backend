CREATE PROCEDURE sp_NewsletterSubscriber_clearCategories
	@Id INT
AS
BEGIN

	DELETE NewsletterSubscriberCategory WHERE NewsletterSubscriberId = @Id

END