CREATE PROCEDURE [dbo].[sp_testData_createSampleSatellite]
AS
BEGIN

	-- Insert Sample Functions
	INSERT SampleFunction (
		Code,
		Name,
		TenantId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Code = data.Code,
		Name = data.Name,
		TenantId = 1,
		CreatedBy = 1,
		UpdatedBy = 1
	FROM (
		SELECT Code = 'X', Name=  'Test' UNION
		SELECT Code = 'S', Name=  'Standard' UNION
		SELECT Code = 'E', Name=  'Empty' UNION
		SELECT Code = 'C', Name=  'Control' UNION
		SELECT Code = 'B', Name=  'Blank'
	) AS data

	-- Insert Sample Types
	INSERT SampleType (
		Name,
		TenantId,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Name = data.Name,
		TenantId = 1,
		CreatedBy = 1,
		UpdatedBy = 1
	FROM (
		SELECT Name = 'Sangre' UNION 
		SELECT Name = 'Feces' UNION 
		SELECT Name = 'ADN' UNION 
		SELECT Name = 'ARN' UNION 
		SELECT Name = 'Saliva' 
	) AS data

	-- INSERT Unit Of Measures
	INSERT UnitOfMeasure (
		Code,
		DefaultDescription,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Code = data.descr,
		DefaultDescription = data.descr,
		CreatedBy = 1,
		UpdatedBy = 1
	FROM (
		SELECT descr = 'cm3' UNION
		SELECT descr = 'moles' UNION
		SELECT descr = 'litro'
	) AS data

END