CREATE PROCEDURE sp_ClientCompanyBillingInformation_create
	@Id INT,
	@StreetName NVARCHAR(200),
	@StreetNumber NVARCHAR(200),
	@City NVARCHAR(200),
	@PostalCode NVARCHAR(70),
	@Department NVARCHAR(200),
	@ProvinceId INT
AS
BEGIN

	INSERT ClientCompanyBillingInformation (
		Id,
		StreetName,
		StreetNumber,
		City,
		PostalCode,
		Department,
		ProvinceId
	)
	SELECT
		Id = @Id,
		StreetName = @StreetName,
		StreetNumber = @StreetNumber,
		City = @City,
		PostalCode = @PostalCode,
		Department = @Department,
		ProvinceId = @ProvinceId

END