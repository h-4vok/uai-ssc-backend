CREATE PROCEDURE sp_User_create
	@userName NVARCHAR(200),
	@password NVARCHAR(200),
	@clientCompanyId INT,
	@createdBy INT = 1
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
		FirstName = NULL,
		LastName = NULL,
		ClientId = @clientCompanyId,
		TitleInCompany = NULL,
		IsEnabledInCompany = 1,
		LoginFailures = 0,
		CreatedBy = @createdBy,
		UpdatedBy = @createdBy

	SELECT SCOPE_IDENTITY()

END