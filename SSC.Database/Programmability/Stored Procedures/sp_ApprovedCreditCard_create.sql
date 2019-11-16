CREATE PROCEDURE [dbo].[sp_ApprovedCreditCard_create]
	@Number NVARCHAR(19),
	@Owner NVARCHAR(100),
	@CCV INT,
	@ExpirationDateMMYY NVARCHAR(4)
AS
BEGIN

	INSERT ApprovedCreditCard (
		Number,
		Owner,
		CCV,
		ExpirationDateMMYY
	)
	SELECT
		Number = @Number,
		Owner = @Owner,
		CCV = @CCV,
		ExpirationDateMMYY = @ExpirationDateMMYY

END