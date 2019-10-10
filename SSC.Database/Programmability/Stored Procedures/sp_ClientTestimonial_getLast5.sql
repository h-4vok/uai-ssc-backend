CREATE PROCEDURE sp_ClientTestimonial_getLast5
AS
BEGIN

	SELECT
		ct.Id,
		ct.PersonFullName,
		ClientCompanyId = c.Id,
		ClientCompanyName = c.Name,
		ct.Text,
		ct.CreatedBy,
		ct.CreatedDate,
		ct.UpdatedBy,
		ct.UpdatedDate

	FROM		ClientTestimonial CT

	LEFT  JOIN	ClientCompany C
			ON	ct.ClientId = c.Id

END