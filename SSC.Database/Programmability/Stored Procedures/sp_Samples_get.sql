CREATE PROCEDURE sp_Samples_get
	@StatusCode NVARCHAR(100)
AS
BEGIN

	SELECT
		s.Id,
		s.Barcode,
		SampleTypeCode = st.Name,
		AvailableVolume = s.CurrentVolume,
		UnitOfMeasureCode = uom.Code

	FROM		Sample S

	INNER JOIN	SampleType ST
			ON	s.SampleTypeId = st.Id

	INNER JOIN	UnitOfMeasure UOM
			ON	s.UnitOfMeasureId = uom.Id

	WHERE		s.StatusCode = @StatusCode

END