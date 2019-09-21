CREATE PROCEDURE sp_ClientCompanyCreditCard_create
	@ClientId INT,
	@Number NVARCHAR(30),
	@Owner NVARCHAR(500),
	@CCV INT,
	@ExpirationDateMMYY NVARCHAR(4),
	@IsDefault BIT
AS
BEGIN

	INSERT ClientCompanyCreditCard (
		ClientId,
		Number,
		Owner,
		CCV,
		ExpirationDateMMYY,
		IsDefault,
		CreatedDate,
		UpdatedDate
	)
	SELECT
		ClientId = @ClientId,
		Number = @Number,
		Owner = @Owner,
		CCV = @CCV,
		ExpirationDateMMYY = @ExpirationDateMMYY,
		IsDefault = @IsDefault,
		CreatedDate = GETUTCDATE(),
		UpdatedDate = GETUTCDATE()

END