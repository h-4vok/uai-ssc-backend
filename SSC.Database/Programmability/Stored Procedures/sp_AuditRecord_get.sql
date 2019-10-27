CREATE PROCEDURE sp_AuditRecord_get
	@Id INT
AS
BEGIN

	SELECT
		Id = ar.Id,
		CreatedDate = ar.CreatedDate,
		UserReference = ar.UserReference,
		ClientId = ar.ClientId,
		AuditTypeId = at.Id,
		AuditTypeDescription = at.Name,
		Message = ar.Message

	FROM		AuditRecord AR

	INNER JOIN	AuditType AT
			ON	ar.AuditTypeId = at.Id

	WHERE		ar.Id = @Id

END