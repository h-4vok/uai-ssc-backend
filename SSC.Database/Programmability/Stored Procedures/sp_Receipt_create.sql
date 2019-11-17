CREATE PROCEDURE sp_Receipt_create
	@ClientId INT,
	@ReceiptTypeCode NVARCHAR(500),
	@CreatedBy INT
AS
BEGIN

	-- Ultima numeracion
	DECLARE @NewNumber INT
	DECLARE @ReceiptTypeId INT

	SELECT 
		@NewNumber = LastNumber, 
		@ReceiptTypeId = Id
	FROM		ReceiptType RT
	WHERE		Code = @ReceiptTypeCode

	-- Creo numeracion nueva
	SET @NewNumber = @NewNumber + 1

	-- Inserto numeracion nueva
	UPDATE
		ReceiptType

	SET
		LastNumber = @NewNumber

	WHERE		Id = @ReceiptTypeId

	-- Insert encabezado de factura
	INSERT Receipt (
		ClientId,
		ReceiptNumber,
		ReceiptTypeId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		ClientId = @ClientId,
		ReceiptNumber = @NewNumber,
		ReceiptTypeId = @ReceiptTypeId,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	-- Devuelvo ID
	SELECT SCOPE_IDENTITY()

END