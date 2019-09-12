CREATE PROCEDURE sp_ClientCompany_exists
	@name NVARCHAR(200)
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1)
	FROM		ClientCompany
	WHERE		Name = @name

END