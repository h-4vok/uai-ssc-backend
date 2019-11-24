CREATE PROCEDURE [dbo].[sp_testData_createSampleSatellite]
AS
BEGIN

	-- Work Order Status
	INSERT WorkOrderStatus (
		Code,
		Description,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Code = data.Code,
		Description = data.Descr,
		CreatedBy = 1,
		UpdatedBy = 1
	FROM (
		SELECT Code = 'draft', Descr = 'Borrador' UNION
		SELECT Code = 'checking', Descr = 'En Comprobación' UNION
		SELECT Code = 'executing', Descr = 'En Ejecución' UNION
		SELECT Code = 'completed', Descr = 'Completado' UNION
		SELECT Code = 'cancelled', Descr = 'Cancelado'
	) AS data

	-- Work Order Types
	INSERT WorkOrderType (
		Code,
		Description,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Code = 'aliquot',
		Description = 'Generar Alícuotas',
		CreatedBy = 1,
		UpdatedBy = 1
	UNION SELECT
		Code = 'eleuetes',
		Description = 'Generar Eleuetes',
		CreatedBy = 1,
		UpdatedBy = 1

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