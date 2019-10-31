CREATE PROCEDURE Backup_get
AS
BEGIN

	SELECT
		Id,
		FilePath,
		BackupDate,
		CreatedBy
	FROM		[Backup]

END