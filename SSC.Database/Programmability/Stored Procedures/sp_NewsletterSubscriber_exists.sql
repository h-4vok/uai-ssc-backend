CREATE PROCEDURE sp_NewsletterSubscriber_exists
	@Email NVARCHAR(500)
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)
	FROM		NewsletterSubscriber
	WHERE		Email = @Email

END