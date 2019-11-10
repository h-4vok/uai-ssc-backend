CREATE PROCEDURE sp_PlatformUser_createTestUser
	@UserName NVARCHAR(200),
	@CompanyId INT
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
		IsEnabledInCompany,
		LoginFailures,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		UserName = @UserName,
		Password = '1A4+OYh1+avWgZilfsAZY1hBt+Y=',
		IsBlocked = 0,
		IsEnabled = 1,
		FirstName = 'Tester',
		LastName = 'McBug',
		ClientId = @CompanyId,
		IsEnabledInCompany = 1,
		LoginFailures = 0,
		CreatedBy = 1,
		UpdatedBy = 1

	DECLARE @testUserId INT
	SET @testUserId = SCOPE_IDENTITY()

	-- Set roles
	INSERT UserRole (
		UserId,
		RoleId
	)
	SELECT
		UserId = @testUserId,
		RoleId = r.Id
	FROM		Role R
	WHERE		R.Name in ('Científico Ejecutor','Científico Auditor','Controlador de Calidad','Administrador de Cliente')

END