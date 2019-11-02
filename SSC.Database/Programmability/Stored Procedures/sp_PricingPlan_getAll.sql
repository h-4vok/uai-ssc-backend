CREATE PROCEDURE sp_PricingPlan_getAll
	@nameAlike NVARCHAR(500) = NULL,
	@minPrice NUMERIC(12, 2) = NULL,
	@maxPrice NUMERIC(12, 2) = NULL,
	@minRating INT = NULL
AS
BEGIN

	WITH CTE_AvgRating AS (
		SELECT
			ppc.PricingPlanId,
			AverageRating = CAST(AVG(CAST(ppc.Rating AS DECIMAL(3,2))) AS DECIMAL(3,2))

		FROM		PricingPlanComment PPC
		GROUP BY	ppc.PricingPlanId
	)
	
	SELECT
		PP.Id,
		PP.Code,
		PP.Name,
		PP.UserLimit,
		PP.ClinicRehearsalLimit,
		PP.PatientSampleLimit,
		PP.ControlSampleLimit,
		PP.AnualDiscountPercentage,
		PP.Price,
		AverageRating = ISNULL(avgr.AverageRating, 5)
	FROM		PricingPlan PP

	LEFT  JOIN	CTE_AvgRating AVGR
			ON	PP.Id = AVGR.PricingPlanId

	WHERE		(@nameAlike IS NULL OR (@nameAlike IS NOT NULL AND PP.Name LIKE '%' + @nameAlike + '%'))
	AND			(@minPrice IS NULL OR (@minPrice IS NOT NULL AND PP.Price >= @minPrice))
	AND			(@maxPrice IS NULL OR (@maxPrice IS NOT NULL AND PP.Price <= @maxPrice))
	AND			(@minPrice IS NULL OR (@minRating IS NOT NULL AND (avgr.AverageRating IS NULL OR avgr.AverageRating >= @minRating)))

END