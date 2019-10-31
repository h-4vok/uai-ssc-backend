CREATE PROCEDURE Backup_perform
	@filepath NVARCHAR(255)
AS
BEGIN

	EXEC Database_killAll 'SSC.Database'

	BACKUP DATABASE [SSC.Database]
	TO DISK = @filepath
	WITH FORMAT,  
      MEDIANAME = 'C_SQLServerBackups',  
      NAME = 'Full Backup of SSC';  

END
