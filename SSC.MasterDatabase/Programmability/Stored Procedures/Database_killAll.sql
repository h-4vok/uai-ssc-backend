CREATE PROCEDURE Database_killAll
	@DBName NVARCHAR(50)
AS
BEGIN
	
	SET NOCOUNT ON
	
	DECLARE @spidstr varchar(8000)
	DECLARE @ConnKilled smallint
	SET @ConnKilled=0
	SET @spidstr = ''

	IF db_id(@DBName) < 4
	BEGIN
		PRINT 'Connections to system databases cannot be killed'
	RETURN
	END

	SELECT 
		@spidstr =  COALESCE(@spidstr,',' ) + 'kill ' + CONVERT(varchar, spid) + '; '

	FROM		master..sysprocesses 
	WHERE		dbid = db_id(@DBName)

	IF LEN(@spidstr) > 0
	BEGIN
		EXEC(@spidstr)
	
		SELECT @ConnKilled = COUNT(1)
	
		FROM		master..sysprocesses 
		WHERE		dbid = db_id(@DBName)

	END
END