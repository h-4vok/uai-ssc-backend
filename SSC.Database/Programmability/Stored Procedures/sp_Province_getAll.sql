﻿CREATE PROCEDURE sp_Province_getAll
AS
BEGIN
	SELECT
		Id,
		Name
	FROM		Province WITH (NOLOCK)
END