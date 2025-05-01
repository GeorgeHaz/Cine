USE [Cine]
GO
Create procedure GetPeliculaSalaCineFromDate
	@fecha Date

AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		id_pelicula_sala,
		salaCineId,
		peliculaId,
		fecha_publicacion,
		fecha_fin
	FROM pelicula_salacine
	WHERE
		CAST(fecha_publicacion AS DATE) >= @fecha
END
GO