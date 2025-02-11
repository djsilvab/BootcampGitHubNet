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

-- Data: LibroPrecioOferta --
INSERT INTO LibroPrecioOferta(LibroId, NuevoPrecio, MensajePromocional)
VALUES(1,30.05, 'Oferta del Mes'),
      (3,35.55,'Oferta del Mes');

-- Data: Autor --      
INSERT INTO Autor(Nombre, WebURL)
VALUES ('Charles Darwin','www.charlesdarwin.com'),
       ('Robert Cecil Martin','www.robertcecil.com');

-- Data: AutorLibro --
INSERT INTO AutorLibro(AutorId, LibroId, Orden)
VALUES(1,1,1),
      (2,3,1);

-- Data: Review --
INSERT INTO Review(LibroId,Votante,Estrellas,Comentario)
VALUES (1,'Roberto Martinez',5,'Excelente libro!!!'),
       (1,'Juan Lopez',4,'Excelente!!!'),
       (3,'Roberto Martinez',4,'Excelente!!!'),
       (3,'Juan Lopez',3,'buen libro');