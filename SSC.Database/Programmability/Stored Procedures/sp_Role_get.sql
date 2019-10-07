CREATE PROCEDURE sp_Role_get
	@id INT
AS
BEGIN

	SELECT
		Id,
		Name,
		IsEnabled,
		IsPlatformRole,
		CreatedBy,
		UpdatedBy,
		CreatedDate,
		UpdatedDate

	FROM		[Role]
	WHERE		Id = @id


END