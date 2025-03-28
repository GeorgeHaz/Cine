USE [Cine]
GO
/****** Object:  StoredProcedure [dbo].[pelicula_por_fecha_especifica]    Script Date: 3/23/2025 5:57:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[pelicula_por_fecha_especifica]
	@Fecha DATE
AS
BEGIN
	SELECT 
		p.nombre AS Nombre,
		p.duracion AS Duracion,
		psc.fecha_publicacion AS FechaPublicacion,
		psc.fecha_fin AS FechaFin
	FROM pelicula_salacine as psc
	INNER JOIN pelicula p ON p.id_pelicula = psc.id_pelicula
	WHERE psc.fecha_publicacion = @Fecha 
		AND p.activo=1
END