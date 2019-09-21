CREATE PROCEDURE sp_User_create
	@userName NVARCHAR(200),
	@password NVARCHAR(200),
	@clientCompanyId INT,
	@createdBy INT = 1,
	@isClientAdmin BIT = 0,
	@FirstName NVARCHAR(200),
	@LastName NVARCHAR(200)
AS
BEGIN

	INSERT PlatformUser (
		UserName,
		Password,
		IsBlocked,
		IsEnabled,
		FirstName,
		LastName,
		ClientId,
		TitleInCompany,
		IsEnabledInCompany,
		LoginFailures,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		UserName = @userName,
		Password = @password,
		IsBlocked = 0,
		IsEnabled = 1,
		FirstName = @FirstName,
		LastName = @LastName,
		ClientId = @clientCompanyId,
		TitleInCompany = NULL,
		IsEnabledInCompany = 1,
		LoginFailures = 0,
		CreatedBy = @createdBy,
		UpdatedBy = @createdBy

	DECLARE @UserId INT

	SELECT @UserId = SCOPE_IDENTITY()

	IF (@isClientAdmin = 1)
	BEGIN

		DECLARE @RoleId INT

		SELECT @RoleId = Id FROM Role WHERE Name = 'Administrador de Cliente'

		IF (@RoleId > 0)
		BEGIN

			EXEC sp_UserRole_create @UserId, @RoleId, @UserId

		END

	END

	SELECT @UserId

END