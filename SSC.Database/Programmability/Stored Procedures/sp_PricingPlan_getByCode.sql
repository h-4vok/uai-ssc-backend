CREATE PROCEDURE sp_PricingPlan_getByCode
	@Code NVARCHAR(70)
AS
BEGIN

	WITH CTE_AvgRating AS (
		SELECT
			ppc.PricingPlanId,
			AverageRating = CAST(AVG(CAST(ppc.Rating AS DECIMAL(3,2))) AS DECIMAL(3,2))

		FROM		PricingPlanComment PPC
		INNER JOIN	PricingPlan PP
				ON	ppc.PricingPlanId = pp.Id

		WHERE		pp.Code = @Code
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
		AverageRating = ISNULL(AVGR.AverageRating, 5)
	FROM		PricingPlan PP
	LEFT  JOIN	CTE_AvgRating AVGR
			ON	pp.Id = avgr.PricingPlanId

	WHERE		Code = @Code

END