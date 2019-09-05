USE UBER;
--1.	Mostrar los nombres (ordenados Z .. A) de los conductores sin repeticiones y la columna se debe llamar nombreCond. F
SELECT distinct conductor.NomCond from conductor as nombreCond order by NomCond desc; 
--2.	Obtener el id del conductor, su nombre y los id de las rutas en las que trabaja. F
select conductor.idCond, NomCond, idRuta from conductor inner join ruta on conductor.idCond = ruta.idCond;
--3.	Listar el (o los) id del conductor (es) que trabaja (n) en Perisur. 
select conductor.idCond from viaje 
inner join ruta_viaje on viaje.idViaje = ruta_viaje.idViaje
inner join ruta on ruta.idRuta=ruta_viaje.idRuta
inner join conductor on ruta.idCond=conductor.idCond
where viaje.direccion like 'perisur';
--4.	Los Ids de las rutas con el mayor número de viajes. F
select ruta.idRuta from ruta where ruta.numeroViajes= (select max(ruta.numeroViajes) from ruta);
--5.	Obtener el promedio de viajes del conductor PEPE. F
select avg(ruta.numeroViajes) as promViajesPepe from conductor inner join ruta on conductor.idCond=ruta.idCond where conductor.nomCond='pepe';

--6.	Listar el modelo de los autos que tengan viajes en Chapultepec o reforma, pero no en lomas.
select coche.modelo from coche
inner join ruta on ruta.idCoche=coche.id_coche
inner join ruta_viaje on ruta.idRuta = ruta_viaje.idRuta
inner join viaje on viaje.idViaje = ruta_viaje.idViaje
where viaje.direccion like 'chapultepec'
or viaje.direccion like 'reforma'
and viaje.direccion not like 'lomas';
--7.	Mostrar el id de las rutas que tienen más de un viaje registrado. F
select ruta.idRuta, ruta.numeroViajes from ruta where numeroViajes>1;
--8.	Obtener el nombre de los conductores que tienen viajes tanto a Perisur como a barranca (a ambos, no sólo a uno u otro).  F
select conductor.NomCond from conductor inner join viaje on conductor.idCond=viaje.idCond where viaje.direccion='perisur' and viaje.direccion='barranca'; 