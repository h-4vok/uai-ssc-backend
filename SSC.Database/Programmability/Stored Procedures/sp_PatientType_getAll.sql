CREATE PROCEDURE sp_PatientType_getAll
AS
BEGIN

	SELECT
		pt.Id,
		pt.Code,
		pt.Description

	FROM		PatientType PT

END