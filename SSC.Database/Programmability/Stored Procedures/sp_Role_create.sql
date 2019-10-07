CREATE PROCEDURE sp_Role_create
	@name NVARCHAR(300),
	@createdBy INT
AS
BEGIN

	INSERT [Role] (
		Name,
		IsPlatformRole,
		IsEnabled,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Name = @name,
		IsPlatformRole = 1,
		IsEnabled = 1,
		CreatedBy = @createdBy,
		UpdatedBy = @createdBy

	SELECT SCOPE_IDENTITY()

END