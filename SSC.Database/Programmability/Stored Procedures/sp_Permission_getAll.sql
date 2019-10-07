CREATE PROCEDURE sp_Permission_getAll
AS
BEGIN

	SELECT
		p.Id,
		p.Name,
		p.Code
	FROM		Permission P

END