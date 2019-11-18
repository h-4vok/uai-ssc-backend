CREATE PROCEDURE sp_PrintableBill_getHeader
	@ReceiptId INT
AS
BEGIN

	WITH CTE_Receipt_HasCreditCard AS (
		SELECT TOP 1
			r.Id,
			CONVERT(BIT, 1) AS IsCreditCardSale

		FROM		Receipt R
		INNER JOIN	ClientCompanyTransaction CCT
				ON	r.Id = cct.ReceiptId

		INNER JOIN	ClientCompanyTransactionPayment CCTP
				ON	cct.Id = cctp.ClientTransactionId

		WHERE		(cctp.ClientCreditCardId IS NOT NULL OR cctp.CreditCardNumber IS NOT NULL)
		AND			r.Id = @ReceiptId
	),
	CTE_Receipt_HasCreditNote AS (
		SELECT TOP 1
			r.Id,
			CONVERT(BIT, 1) AS IsCreditNoteSale

		FROM		Receipt R
		INNER JOIN	ClientCompanyTransaction CCT
				ON	r.Id = cct.ReceiptId

		INNER JOIN	ClientCompanyTransactionPayment CCTP
				ON	cct.Id = cctp.ClientTransactionId

		WHERE		cctp.CreditNoteId IS NOT  NULL AND r.Id = @ReceiptId
	)
	SELECT
		r.ReceiptNumber,
		r.IsNullified,
		cct.TransactionDate,
		ccbi.LegalName,
		ccbi.TaxCode,
		cca.City,
		cca.StreetName,
		cca.StreetNumber,
		cca.PostalCode,
		cca.Department,
		ProvinceName = p.Name,
		IsCreditCardSale = CONVERT(BIT, CASE WHEN hcc.IsCreditCardSale IS NOT NULL THEN 1 ELSE 0 END),
		IsCreditNoteSale = CONVERT(BIT, CASE WHEN hcn.IsCreditNoteSale IS NOT NULL THEN 1 ELSE 0 END),
		cct.Total

	FROM		Receipt R

	INNER JOIN	ClientCompanyTransaction CCT
			ON	r.Id = cct.ReceiptId

	INNER JOIN	ClientCompanyBillingInformation CCBI
			ON	cct.ClientId = ccbi.Id

	INNER JOIN	ClientCompanyAddress CCA
			ON	cct.ClientId = cca.ClientCompanyId

	INNER JOIN	Province P
			ON	CCA.ProvinceId = P.Id

	LEFT  JOIN	CTE_Receipt_HasCreditCard HCC
			ON	r.Id = hcc.Id

	LEFT  JOIN	CTE_Receipt_HasCreditNote HCN
			ON	r.Id = hcn.Id

	WHERE		r.Id = @ReceiptId

END