CREATE PROCEDURE sp_User_getPassword
	@Id INT
AS
BEGIN

	SELECT Password FROM PlatformUser WHERE Id = @Id

END