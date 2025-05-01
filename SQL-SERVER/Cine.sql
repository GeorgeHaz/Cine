CREATE DATABASE Cine
GO

USE Cine
GO

CREATE TABLE pelicula(
	id_pelicula INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre NVARCHAR(255) NOT NULL,
	duracion INT NOT NULL,
	activo INT NOT NULL,
	fecha_eliminacion DATETIME
)
GO

CREATE TABLE sala_cine(
	id_sala_cine INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre NVARCHAR(255) NOT NULL,
	estado INT NOT NULL,
	activo INT NOT NULL,
	fecha_eliminacion DATETIME
)
GO

CREATE TABLE pelicula_salacine(
	id_pelicula_sala INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	id_sala_cine INT NOT NULL,
	fecha_publicacion DATE NOT NULL,
	fecha_fin DATE NOT NULL,
	id_pelicula INT NOT NULL,

	CONSTRAINT fk_pelicula_salacine_sala_cine FOREIGN KEY(id_sala_cine) REFERENCES sala_cine(id_sala_cine),
	CONSTRAINT fk_pelicula_salacine_pelicula FOREIGN KEY(id_pelicula) REFERENCES pelicula(id_pelicula)
)
GO