CREATE PROCEDURE Backup_new
	@filepath NVARCHAR(1000),
	@CreatedBy NVARCHAR(500)
AS
BEGIN

	INSERT [Backup] (
		FilePath,
		BackupDate,
		CreatedBy
	)
	SELECT
		FilePath = @filepath,
		BackupDate = GETDATE(),
		CreatedBy = @CreatedBy

END