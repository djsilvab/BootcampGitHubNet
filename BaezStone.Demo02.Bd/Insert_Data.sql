-- Data: Categoria --
INSERT INTO Categoria(Nombre) Values('Computadoras'),('Impresoras');

-- Data: Marca --
INSERT INTO Marca(Nombre) Values('HP'),('Apple');

-- Data: Producto --
insert into Producto(Nombre,Precio,Costo,CategoriaId,MarcaId)
values('Lenovo Thinkpad L480',2000,1500,1,1),
      ('HP - Envy',2000,1500,1,1);

-- Data: PrecioOferta --
INSERT INTO PrecioOferta(NuevoPrecio,TextoPromocional,ProductoId)
VALUES(1800,'Oferta de verano',1);