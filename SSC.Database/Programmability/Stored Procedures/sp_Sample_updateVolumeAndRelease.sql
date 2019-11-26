CREATE PROCEDURE sp_Sample_updateVolumeAndRelease
	@SampleId INT,
	@VolumeToDecrease NUMERIC(12, 2)
AS
BEGIN

	UPDATE
		Sample

	SET
		CurrentVolume = CurrentVolume - @VolumeToDecrease,
		StatusCode = CASE WHEN (CurrentVolume - @VolumeToDecrease) <= 0 THEN 'retired' ELSE 'available' END

	WHERE
		Id = @SampleId

END