CREATE PROCEDURE sp_NewsletterSubscriber_delete
	@Email NVARCHAR(500)
AS
BEGIN

	DECLARE @Id INT

	SELECT @Id = Id FROM NewsletterSubscriber WHERE Email = @Email

	DELETE NewsletterSubscriberCategory WHERE NewsletterSubscriberId = @Id
	DELETE NewsletterSubscriber WHERE Id = @Id

END