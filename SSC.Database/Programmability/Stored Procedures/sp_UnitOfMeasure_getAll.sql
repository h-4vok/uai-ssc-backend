CREATE PROCEDURE sp_UnitOfMeasure_getAll
AS
BEGIN

	SELECT
		uom.Id,
		uom.Code,
		uom.DefaultDescription

	FROM		UnitOfMeasure UOM

END