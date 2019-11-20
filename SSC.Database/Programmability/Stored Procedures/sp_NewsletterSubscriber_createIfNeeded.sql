CREATE PROCEDURE sp_NewsletterSubscriber_createIfNeeded
	@Email NVARCHAR(500)
AS
BEGIN

	DECLARE @SubscriberId INT

	SELECT @SubscriberId = Id FROM NewsletterSubscriber WHERE Email = @Email

	IF (@SubscriberId IS NOT NULL)
	BEGIN
		SELECT @SubscriberId
		RETURN
	END

	INSERT NewsletterSubscriber (
		Email
	)
	SELECT
		Email = @Email

	SELECT SCOPE_IDENTITY()

END