CREATE PROCEDURE sp_PlatformMenu_delete
	@Id INT
AS
BEGIN

	-- Clean menu
	EXEC sp_PlatformMenu_clean @Id

	-- Delete menu
	DELETE PlatformMenu WHERE Id = @Id

END