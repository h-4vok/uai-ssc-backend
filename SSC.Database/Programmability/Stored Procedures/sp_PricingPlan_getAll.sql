CREATE PROCEDURE sp_PricingPlan_getAll
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

END