/*INGRESO DE SALACINE*/
INSERT INTO sala_cine(id_sala,nombre,estado,audit_delete_date,audit_delete_user) VALUES (1,'Sala 01','Sala Disponible',null,null);
INSERT INTO sala_cine(id_sala,nombre,estado,audit_delete_date,audit_delete_user) VALUES (2,'Sala 02','Sala Disponible',null,null);
INSERT INTO sala_cine(id_sala,nombre,estado,audit_delete_date,audit_delete_user) VALUES (3,'Sala 03','Sala Disponible',null,null);
INSERT INTO sala_cine(id_sala,nombre,estado,audit_delete_date,audit_delete_user) VALUES (4,'Sala 04','Sala Disponible',null,null);
INSERT INTO sala_cine(id_sala,nombre,estado,audit_delete_date,audit_delete_user) VALUES (5,'Sala 05','Sala Disponible',null,null);

/*INGRESO DE PELICULAS*/
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (1,'Volver al Futuro 1',190,'2025-03-20',null,null);
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (2,'Volver al Futuro 2',180,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (3,'Volver al Futuro 3',160,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (4,'Volver al Futuro 4',240,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (5,'Interestellar',240,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (6,'Star Wars',180,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (7,'Happy Feet',220,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (8,'Happy Feet 2',190,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (9,'Avengers',240,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (10,'Capitarn America',220,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (11,'Attack of Titan',180,'2025-03-20',null,null); 
INSERT INTO pelicula (id_pelicula,nombre,duracion,fecha_publicacion,audit_delete_date,audit_delete_user) VALUES (12,'Insidious',160,'2025-03-20',null,null); 

/*INGRESO DE PELICULAS EN SALAS DE CINE*/
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (1,'2025-03-23','2025-03-23',1,1);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (2,'2025-01-20','2025-02-23',2,1);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (3,'2025-02-22','2025-02-23',3,1);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (4,'2025-01-25','2025-02-23',4,2);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (5,'2025-02-10','2025-02-23',5,2);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (6,'2025-02-15','2025-02-23',6,2);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (7,'2025-03-10','2025-02-23',7,2);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (8,'2025-03-22','2025-02-23',8,3);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (9,'2025-02-12','2025-02-23',9,3);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (10,'2025-03-17','2025-02-23',2,3);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (11,'2025-02-16','2025-02-23',1,3);
INSERT INTO pelicula_salacine (id_pelicula_sala,fecha_publicacion,fecha_fin,peliculaId,salaCineId) VALUES (12,'2025-01-30','2025-02-23',3,3);

