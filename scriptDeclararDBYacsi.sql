--definición de las tablas del ejercicio de UBER
--modelo relacional 
--coche( idCoche(pk), modelo, placa
--conductor( idConductor(pk), telefono, nomConductor)
viaje(idViaje(pk) 
-- SCRIPT:

create table coche(
	idcoche smallint not null primary key,
	modelo char(30),
	placa char(9) );

create table conductor(
	idConductor smallint not null primary key,
	telefono char(30),
	nomConductor char(9) );

create table viaje(
	idViaje smallint not null primary key,
	direccion char(30), );

create table ruta(
	idRuta smallint not null primary key,
	numeroViajes smallint,
	primary key (idViaje, idRuta) );

create table rutaViaje(
	idViaje smallint references viaje,
	idRuta smallint,
	primary key (idViaje, idRuta) );

