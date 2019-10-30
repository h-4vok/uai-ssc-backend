CREATE PROCEDURE sp_PricingPlan_getAll
	@nameAlike NVARCHAR(500) = NULL,
	@minPrice NUMERIC(12, 2) = NULL,
	@maxPrice NUMERIC(12, 2) = NULL,
	@minRating INT = NULL
AS
BEGIN
	
	SELECT
		Id,
		Code,
		Name,
		UserLimit,
		ClinicRehearsalLimit,
		PatientSampleLimit,
		ControlSampleLimit,
		AnualDiscountPercentage,
		Price
	FROM		PricingPlan

	WHERE		(@nameAlike IS NULL OR (@nameAlike IS NOT NULL AND Name LIKE '%' + @nameAlike + '%'))
	AND			(@minPrice IS NULL OR (@minPrice IS NOT NULL AND Price >= @minPrice))
	AND			(@maxPrice IS NULL OR (@maxPrice IS NOT NULL AND Price <= @maxPrice))

END