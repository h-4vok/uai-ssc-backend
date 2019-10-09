CREATE PROCEDURE sp_SystemLanguage_get
	@code NVARCHAR(500)
AS
BEGIN

	SELECT
		Id,
		Code,
		Name,
		CreatedDate,
		CreatedBy,
		UpdatedDate,
		UpdatedBy
	FROM		SystemLanguage
	WHERE		Code = @code

END