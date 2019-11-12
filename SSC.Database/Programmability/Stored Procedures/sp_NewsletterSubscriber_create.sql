CREATE PROCEDURE sp_NewsletterSubscriber_create
	@Email NVARCHAR(500)
AS
BEGIN

	INSERT NewsletterSubscriber (
		Email
	)
	SELECT
		Email = @Email

END