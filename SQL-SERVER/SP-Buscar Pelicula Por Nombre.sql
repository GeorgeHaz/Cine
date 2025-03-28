USE [Cine]
GO
/****** Object:  StoredProcedure [dbo].[buscar_pelicula_nombre]    Script Date: 3/23/2025 5:56:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[buscar_pelicula_nombre]
	@Nombre NVARCHAR(255)
AS
BEGIN
	SELECT 
		p.id_pelicula,
		p.nombre,
		p.duracion,
		p.activo,
		p.fecha_eliminacion
	FROM pelicula AS p
	WHERE p.nombre LIKE '%' + @Nombre + '%' 
		AND p.activo=1 
END