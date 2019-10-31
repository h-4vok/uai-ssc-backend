IF NOT EXISTS (SELECT [name]
                FROM [sys].[database_principals]
                WHERE [type] = N'S' AND [name] = N'ssc')
BEGIN
	CREATE USER ssc FOR LOGIN ssc;
	EXEC sp_addrolemember N'db_owner', N'ssc';
	EXEC sp_addrolemember N'db_backupoperator', N'ssc';
END