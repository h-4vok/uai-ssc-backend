CREATE PROCEDURE sp_UnitOfMeasure_getAll
AS
BEGIN

	SELECT
		uom.Id,
		uom.Code,
		uom.DefaultDescription,
		uom.IsEnabled

	FROM		UnitOfMeasure UOM

END