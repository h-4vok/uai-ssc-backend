CREATE PROCEDURE sp_User_update
	@Id INT,
	@UserName NVARCHAR(200),
	@ClientCompanyId INT = NULL,
	@UpdatedBy INT
AS
BEGIN

	UPDATE
		PlatformUser
	SET
		UserName = @UserName,
		ClientId = @ClientCompanyId,
		UpdatedBy = @UpdatedBy
	WHERE
		Id = @Id

END