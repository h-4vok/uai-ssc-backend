
CREATE PROCEDURE sp_ClientCompanyBillingInformation_create
	@Id INT,
	@LegalName NVARCHAR(500),
	@TaxCode NVARCHAR(16),
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
		LegalName,
		TaxCode,
		StreetName,
		StreetNumber,
		City,
		PostalCode,
		Department,
		ProvinceId,
		CreatedDate,
		UpdatedDate
	)
	SELECT
		Id = @Id,
		LegalName = @LegalName,
		TaxCode = @TaxCode,
		StreetName = @StreetName,
		StreetNumber = @StreetNumber,
		City = @City,
		PostalCode = @PostalCode,
		Department = @Department,
		ProvinceId = @ProvinceId,
		CreatedDate = GETUTCDATE(),
		UpdatedDate = GETUTCDATE()

END