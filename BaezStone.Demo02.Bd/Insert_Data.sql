-- Data: Categoria --
INSERT INTO Categoria(Nombre) Values('Computadoras'),('Impresoras');
INSERT INTO Categoria(Nombre) Values('Científico'),('Didácticos'),('Técnicos'),('Programación');

-- Data: Marca --
INSERT INTO Marca(Nombre) Values('HP'),('Apple');

-- Data: Producto --
insert into Producto(Nombre,Precio,Costo,CategoriaId,MarcaId)
values('Lenovo Thinkpad L480',2000,1500,1,1),
      ('HP - Envy',2000,1500,1,1);

-- Data: PrecioOferta --
INSERT INTO PrecioOferta(NuevoPrecio,TextoPromocional,ProductoId)
VALUES(1800,'Oferta de verano',1);

-- Data: Libro --
INSERT INTO Libro(CategoriaId, Titulo, Descripcion, Publicado, Precio)
values(1002,'El origen de las especies','Libro de evolucación','07-31-1859',35.5),
      (1005,'Clean Code','Buenas practicas de programacion','07-31-2005',42.05),
      (1005,'El programador pragmatico','Buenas practicas de programacion','08-13-2018',43.15),
      (1004,'Breve historia del tiempo','Libro acerca del tiempo','07-31-1988',38.75);