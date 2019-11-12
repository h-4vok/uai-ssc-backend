CREATE PROCEDURE sp_NewsletterSubscriber_delete
	@Email NVARCHAR(500)
AS
BEGIN

	DELETE NewsletterSubscriber WHERE Email = @Email

END