CREATE PROCEDURE sp_PrintableBill_getLines
	@ReceiptId INT
AS
BEGIN

	SELECT
		Quantity = 1,
		Detail = rl.Concept,
		UnitPrice = rl.Subtotal,
		TotalPrice = rl.Subtotal,
		LineTaxes = rl.Taxes

	FROM		Receipt R

	INNER JOIN	ReceiptLine RL
			ON	r.Id = rl.ReceiptId

	WHERE		r.Id = @ReceiptId

END