CREATE PROCEDURE sp_ClientManagement_getProfitReport
	@DateFrom NVARCHAR(8),
	@DateTo NVARCHAR(8)
AS
BEGIN

	SELECT
		Date = CONVERT(DATE, TransactionDate),
		Profit = SUM(Total)

	FROM		ClientCompanyTransaction

	WHERE		convert(date, TransactionDate) >= @DateFrom
	AND			convert(date, TransactionDate) <= @DateTo

	GROUP BY
		CONVERT(DATE, TransactionDate)

	ORDER BY
		CONVERT(DATE, TransactionDate) ASC

END