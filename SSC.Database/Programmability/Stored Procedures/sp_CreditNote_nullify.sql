CREATE PROCEDURE sp_CreditNote_nullify
	@CreditNoteId INT
AS
BEGIN

	UPDATE
		Receipt
	
	SET
		IsNullified = 1

	WHERE
		Id = @CreditNoteId

END