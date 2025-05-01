GO
CREATE DATABASE CINE
GO
USE [Cine]
GO

CREATE TABLE [dbo].[pelicula](
	[id_pelicula] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[duracion] [int] NOT NULL,
	[fecha_publicacion] [datetime2](7) NOT NULL,
	[audit_delete_date] [datetime2](7) NULL,
	[audit_delete_user] [int] NULL,
 CONSTRAINT [PK_pelicula] PRIMARY KEY CLUSTERED 
(
	[id_pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[sala_cine](
	[id_sala] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](max) NOT NULL,
	[audit_delete_date] [datetime2](7) NULL,
	[audit_delete_user] [int] NULL,
 CONSTRAINT [PK_sala_cine] PRIMARY KEY CLUSTERED 
(
	[id_sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[pelicula_salacine](
	[id_pelicula_sala] [int] IDENTITY(1,1) NOT NULL,
	[salaCineId] [int] NOT NULL,
	[peliculaId] [int] NOT NULL,
	[fecha_publicacion] [datetime2](7) NOT NULL,
	[fecha_fin] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_pelicula_salacine] PRIMARY KEY CLUSTERED 
(
	[id_pelicula_sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[pelicula_salacine]  WITH CHECK ADD  CONSTRAINT [FK_pelicula_salacine_pelicula_peliculaId] FOREIGN KEY([peliculaId])
REFERENCES [dbo].[pelicula] ([id_pelicula])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[pelicula_salacine] CHECK CONSTRAINT [FK_pelicula_salacine_pelicula_peliculaId]
GO

ALTER TABLE [dbo].[pelicula_salacine]  WITH CHECK ADD  CONSTRAINT [FK_pelicula_salacine_sala_cine_salaCineId] FOREIGN KEY([salaCineId])
REFERENCES [dbo].[sala_cine] ([id_sala])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[pelicula_salacine] CHECK CONSTRAINT [FK_pelicula_salacine_sala_cine_salaCineId]
GO
