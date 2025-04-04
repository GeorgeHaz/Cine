USE [Cine]
GO
/****** Object:  StoredProcedure [dbo].[sala_cine_disponibilidad]    Script Date: 3/23/2025 5:58:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sala_cine_disponibilidad]
	@Nombre NVARCHAR(255)
AS
BEGIN
	DECLARE @CantidadPeliculas int;
	IF NOT EXISTS(
		SELECT 1 
		FROM sala_cine 
		WHERE nombre = @Nombre AND activo = 1)
	BEGIN
		SELECT 'Sala no encontrada o inactiva' AS Mensaje;
		RETURN;
	END
	
	SELECT @CantidadPeliculas=Count(ps.id_pelicula) 
	FROM pelicula_salacine as ps
	INNER JOIN sala_cine sc ON ps.id_sala_cine = sc.id_sala_cine
	WHERE sc.nombre = @Nombre AND sc.activo=1

	IF(@CantidadPeliculas < 3)
		SELECT 'Sala disponible' AS Mensaje;
	ELSE IF(@CantidadPeliculas BETWEEN 3 AND 5)
		SELECT CONCAT('Sala con ',@CantidadPeliculas,' peliculas asignadas') AS Mensaje;
	ELSE
		SELECT 'Sala no disponible' as Mensaje;
END