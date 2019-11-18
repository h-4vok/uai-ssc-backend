CREATE PROCEDURE [dbo].[sp_Receipt_getBoughtMonths]
	@ReceiptId INT
AS
BEGIN

	DECLARE @LinesCount INT

	SELECT @LinesCount = COUNT(1)

	FROM		ReceiptLine
	WHERE		ReceiptId = @ReceiptId


	IF (@LinesCount > 1)
	BEGIN
		SELECT 12
	END
	ELSE
	BEGIN
		SELECT 1
	END

END