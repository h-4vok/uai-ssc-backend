CREATE PROCEDURE sp_Receipt_getNumber
	@Id INT
AS
BEGIN

	SELECT
		ReceiptNumber

	FROM		Receipt

	WHERE		Id = @Id

END