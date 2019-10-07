CREATE PROCEDURE sp_Role_delete
	@id INT
AS
BEGIN

	DELETE [Role]
	WHERE Id = @id

END