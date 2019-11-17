CREATE PROCEDURE sp_CreditCard_create
	@Number NVARCHAR(30),
	@Owner NVARCHAR(500),
	@CCV INT,
	@ExpirationDateMMYY NVARCHAR(4),
	@ClientId INT
AS
BEGIN

	INSERT ClientCompanyCreditCard (
		Number,
		Owner,
		CCV,
		ExpirationDateMMYY,
		ClientId
	)
	SELECT
		Number = @Number,
		Owner = @Owner,
		CCV = @CCV, 
		ExpirationDateMMYY = @ExpirationDateMMYY,
		ClientId = @ClientId

	SELECT SCOPE_IDENTITY()

END