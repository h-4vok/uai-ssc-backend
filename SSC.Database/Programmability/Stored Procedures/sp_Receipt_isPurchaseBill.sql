CREATE PROCEDURE sp_Receipt_isPurchaseBill
	@Id INT
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)

	FROM		Receipt R
	
	INNER JOIN	ReceiptType RT
			ON	r.ReceiptTypeId = rt.Id

	WHERE		r.Id = @Id
	AND			rt.Code = 'purchase-bill'

END