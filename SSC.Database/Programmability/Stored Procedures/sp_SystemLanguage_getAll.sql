CREATE PROCEDURE sp_SystemLanguage_getAll
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

END