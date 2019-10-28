CREATE PROCEDURE sp_AboutUs_address
AS
BEGIN
	SELECT
		Id = 1,
		StreetName = 'Av. Paseo Colón',
		StreetNumber = '524',
		City = 'CABA',
		Department = '1er Piso',
		PostalCode = 'C1063ACS',
		ProvinceId = p.Id,
		ProvinceName = p.Name

	FROM	Province P

	WHERE	p.Name = 'Ciudad Autónoma de Buenos Aires'
END