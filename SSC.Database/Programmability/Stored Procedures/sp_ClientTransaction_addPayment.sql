CREATE PROCEDURE sp_ClientTransaction_addPayment
	@TransactionId INT,
	@ClientCreditCardId INT = NULL,
	@CreditCardNumber NVARCHAR(19) = NULL,
	@CreditCardOwner NVARCHAR(500) = NULL,
	@CreditCardCCV INT = NULL,
	@CreditCardExpirationDateMMYY NVARCHAR(4) = NULL,
	@Amount NUMERIC(12, 2) = NULL,
	@CreditNoteId INT = NULL
AS
BEGIN

	INSERT ClientCompanyTransactionPayment (
		ClientTransactionId,
		ClientCreditCardId,
		CreditCardNumber,
		CreditCardOwner,
		CreditCardCCV,
		CreditCardExpirationDateMMYY,
		Amount,
		CreditNoteId
	)
	SELECT
		ClientTransactionId = @TransactionId,
		ClientCreditCardId = @ClientCreditCardId,
		CreditCardNumber = @CreditCardNumber,
		CreditCardOwner = @CreditCardOwner,
		CreditCardCCV = @CreditCardCCV,
		CreditCardExpirationDateMMYY = @CreditCardExpirationDateMMYY,
		Amount = @Amount,
		CreditNoteId = @CreditNoteId

	SELECT SCOPE_IDENTITY()

END