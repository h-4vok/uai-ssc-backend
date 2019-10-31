CREATE PROCEDURE Backup_getOne
	@id INT
AS
BEGIN

	SELECT
		Id,
		FilePath,
		BackupDate,
		CreatedBy
	FROM		[Backup]
	WHERE		Id = @id

END