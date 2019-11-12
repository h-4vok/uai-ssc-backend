CREATE PROCEDURE sp_NewsletterSubscriber_getAll
AS
BEGIN

	SELECT
		ns.Id,
		ns.Email,
		ns.IsEnabled

	FROM		NewsletterSubscriber NS

END