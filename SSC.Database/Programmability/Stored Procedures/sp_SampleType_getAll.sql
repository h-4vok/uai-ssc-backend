CREATE PROCEDURE sp_SampleType_getAll
	@TenantId INT
AS
BEGIN

	SELECT
		st.Name,
		UpdatedBy = pu.UserName,
		st.UpdatedDate,
		SampleTypeId = st.Id

	FROM		SampleType ST
	
	LEFT  JOIN	PlatformUser PU
			ON	st.UpdatedBy = pu.Id

	WHERE		st.TenantId = @TenantId

END