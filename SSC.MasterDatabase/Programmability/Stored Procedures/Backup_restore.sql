CREATE PROCEDURE Backup_restore
	@filepath NVARCHAR(500),
	@dbname NVARCHAR(50)
AS
BEGIN
	
	-- Kill any open connections to this database
	EXEC Database_killAll @dbname

	-- Restore database using the given backup filename
	RESTORE DATABASE @DBName FROM DISK = @filepath WITH RECOVERY, REPLACE  

END