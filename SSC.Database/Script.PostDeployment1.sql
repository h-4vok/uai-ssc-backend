-- Setup ssc login
CREATE USER ssc FOR LOGIN ssc;
EXEC sp_addrolemember N'db_owner', N'ssc';

-- Satellite Data: Provinces
INSERT Province ( Name )
SELECT
	Name = data.Name
FROM (
	SELECT Name = 'Ciudad Autónoma de Buenos Aires' UNION ALL
	SELECT Name = 'Buenos Aires' UNION ALL
	SELECT Name = 'Catamarca' UNION ALL
	SELECT Name = 'Chaco' UNION ALL
	SELECT Name = 'Chubut' UNION ALL
	SELECT Name = 'Córdoba' UNION ALL
	SELECT Name = 'Corrientes' UNION ALL
	SELECT Name = 'Entre Ríos' UNION ALL
	SELECT Name = 'Formosa' UNION ALL
	SELECT Name = 'Jujuy' UNION ALL
	SELECT Name = 'La Pampa' UNION ALL
	SELECT Name = 'La Rioja' UNION ALL
	SELECT Name = 'Mendoza' UNION ALL
	SELECT Name = 'Neuquén' UNION ALL
	SELECT Name = 'Río Negro' UNION ALL
	SELECT Name = 'Salta' UNION ALL
	SELECT Name = 'San Juan' UNION ALL
	SELECT Name = 'Santa Cruz' UNION ALL
	SELECT Name = 'Santa Fe' UNION ALL
	SELECT Name = 'Santiago del Estero' UNION ALL
	SELECT Name = 'Tierra del Fuego' UNION ALL
	SELECT Name = 'Tucumán'
) data
LEFT  JOIN	Province P
		ON	data.Name = p.Name
WHERE		p.Name IS NULL

-- Initial Data: Default Roles
INSERT Role ( 
	Name, 
	IsPlatformRole,
	IsEnabled
)
SELECT
	Name = data.Name, 
	IsPlatformRole = data.IsPlatformRole,
	IsEnabled = 1
FROM	(
	SELECT Name = 'No Registrado', IsPlatformRole = 1 UNION ALL
	SELECT Name = 'Administrador de Sistema', IsPlatformRole = 1 UNION ALL
	SELECT Name = 'Científico Ejecutor', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Científico Auditor', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Controlador de Calidad', IsPlatformRole = 0 UNION ALL
	SELECT Name = 'Administrador de Cliente', IsPlatformRole = 0
) data
LEFT  JOIN	Role R
		ON	data.Name = r.Name
WHERE		r.Name IS NULL

-- Initial Data: Pricing Plans
INSERT PricingPlan (
	Code,
	Name,
	UserLimit,
	ClinicRehearsalLimit,
	PatientSampleLimit,
	ControlSampleLimit,
	AnualDiscountPercentage,
	Price
)
SELECT
	Code = data.Code,
	Name = data.Name,
	UserLimit = data.UserLimit,
	ClinicRehearsalLimit = data.ClinicRehearsalLimit,
	PatientSampleLimit = data.PatientSampleLimit,
	ControlSampleLimit = data.ControlSampleLimit,
	AnualDiscountPercentage = data.AnualDiscountPercentage,
	Price = data.Price
FROM (
	SELECT
		Code = 'pricing-plan--free',
		Name = 'Gratuito',
		UserLimit = 5,
		ClinicRehearsalLimit = 10,
		PatientSampleLimit = 1000,
		ControlSampleLimit = 1000,
		AnualDiscountPercentage = NULL,
		Price = 0
	UNION ALL
	SELECT
		Code = 'pricing-plan--premium',
		Name = 'Premium',
		UserLimit = 50,
		ClinicRehearsalLimit = NULL,
		PatientSampleLimit = 5000,
		ControlSampleLimit = 5000,
		AnualDiscountPercentage = 10,
		Price = 17500
	UNION ALL
	SELECT
		Code = 'pricing-plan--corporate',
		Name = 'Corporativo',
		UserLimit = NULL,
		ClinicRehearsalLimit = NULL,
		PatientSampleLimit = NULL,
		ControlSampleLimit = NULL,
		AnualDiscountPercentage = 20,
		Price = 50000
) data
LEFT  JOIN	PricingPlan PP
		ON	data.Code = pp.Code
WHERE		pp.CODE IS NULL