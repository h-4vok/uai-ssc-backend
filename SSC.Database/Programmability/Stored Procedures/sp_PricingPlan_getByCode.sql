CREATE PROCEDURE sp_PricingPlan_getByCode
	@Code NVARCHAR(70)
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
	WHERE		Code = @Code

END