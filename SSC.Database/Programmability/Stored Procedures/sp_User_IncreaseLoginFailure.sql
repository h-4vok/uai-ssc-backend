CREATE PROCEDURE sp_User_IncreaseLoginFailure
	@id INT
AS
BEGIN

	DECLARE @LoginFailures INT
	DECLARE @IsBlocked BIT
	SELECT 
		@LoginFailures = LoginFailures,
		@IsBlocked = IsBlocked
	FROM PlatformUser WHERE Id = @id

	SET @LoginFailures = @LoginFailures + 1

	IF (@LoginFailures = 3)
	BEGIN
		SET @IsBlocked = 1
	END

	UPDATE 
		PlatformUser
	SET
		LoginFailures = @LoginFailures,
		IsBlocked = @IsBlocked
	WHERE		Id = @id

	SELECT @IsBlocked

END