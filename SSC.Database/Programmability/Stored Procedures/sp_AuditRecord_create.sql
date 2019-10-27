CREATE PROCEDURE sp_AuditRecord_create
	@UserReference NVARCHAR(200) = '',
	@Message NVARCHAR(MAX),
	@AuditTypeId INT,
	@ClientId INT = 0,
	@CreatedDate SMALLDATETIME
AS
BEGIN

	IF (@ClientId = 0)
	BEGIN
		SET @ClientId = NULL
	END

	INSERT AuditRecord (
		UserReference,
		Message,
		AuditTypeId,
		ClientId,
		CreatedDate
	)
	SELECT
		UserReference = @UserReference,
		Message = @Message,
		AuditTypeId = @AuditTypeId,
		ClientId = @ClientId,
		CreatedDate = @CreatedDate

END