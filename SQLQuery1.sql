select idPedido, idFab, idproducto, cantidad from Pedidos$;

select idFab, idProducto, Descripcion, precio, precio*.16 as iva, precio*1.16 as precioIva from Productos$;

select * from Cliente$ order by NumRepresentante;

select * from Oficinas$ order by Estado, numOficina desc;

select * from Pedidos$ order by Fecha desc;

select top 4 * from Pedidos$ order by cantidad desc;

select top 4 idPedido, precio from Pedidos$, Productos$ where pedidos$.IdProducto=Productos$.idProducto order by precio desc;


select top 4 idPedido, precio from Pedidos$, Productos$ where pedidos$.IdProducto=Productos$.idProducto order by precio*cantidad desc;


select top 4 Pedidos$.* from Pedidos$, Productos$ where pedidos$.IdProducto=Productos$.idProducto order by precio*cantidad desc;

select top 5 Pedidos$.* from Pedidos$, Productos$ where Pedidos$.IdProducto=Productos$.idProducto order by precio desc;

select * from Pedidos$ where month(fecha)=9;