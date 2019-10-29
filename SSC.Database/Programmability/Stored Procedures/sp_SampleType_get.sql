CREATE PROCEDURE sp_SampleType_get
	@Id INT
AS
BEGIN

	SELECT
		st.Id,
		st.Name

	FROM		SampleType ST

	WHERE		st.Id = @Id

END