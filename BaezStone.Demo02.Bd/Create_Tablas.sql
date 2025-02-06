-- Tabla: Categoria --
CREATE TABLE Categoria(
  CategoriaId int NOT NULL IDENTITY,
  Nombre nvarchar(120) NOT NULL
);

ALTER TABLE Categoria
ADD CONSTRAINT Categoria_PK PRIMARY KEY (CategoriaId);

-- Tabla: Marca --
CREATE TABLE Marca(
  MarcaId int NOT NULL IDENTITY,
  Nombre nvarchar(120) NOT NULL
);

ALTER TABLE Marca
ADD CONSTRAINT Marca_PK PRIMARY KEY (MarcaId);

-- Tabla: Producto --
CREATE TABLE Producto(
  ProductoId int NOT NULL IDENTITY,
  Nombre nvarchar(120) NOT NULL,
  Precio numeric(7,2) NOT NULL,
  Costo numeric(7,2) NOT NULL,
  CategoriaId int NOT NULL,
  MarcaId int NOT NULL
);

ALTER TABLE Producto
ADD CONSTRAINT Producto_PK PRIMARY KEY (ProductoId);

ALTER TABLE Producto
ADD CONSTRAINT Producto_Categoria_CategoriaId_FK FOREIGN KEY (CategoriaId)
REFERENCES Categoria (CategoriaId) ON DELETE CASCADE;

ALTER TABLE Producto
ADD CONSTRAINT Producto_Marca_MarcaId FOREIGN KEY (MarcaId)
REFERENCES Marca (MarcaId) ON DELETE CASCADE;

-- Tabla: PrecioOferta --
CREATE TABLE PrecioOferta(
  PrecioOfertaId int NOT NULL IDENTITY,
  NuevoPrecio numeric(7,2) NOT NULL,
  TextoPromocional nvarchar(120) NOT NULL,
  ProductoId int NOT NULL
);

ALTER TABLE PrecioOferta
ADD CONSTRAINT PrecioOferta_PK PRIMARY KEY (PrecioOfertaId);

ALTER TABLE PrecioOferta
ADD CONSTRAINT PrecioOferta_ProductoId_UNQ UNIQUE (ProductoId);

ALTER TABLE PrecioOferta
ADD CONSTRAINT PrecioOferta_Producto_ProductoId_FK FOREIGN KEY (ProductoId)
REFERENCES Producto (ProductoId) ON DELETE CASCADE;

-- Tabla: Libros --
CREATE TABLE Libro(
  LibroId int NOT NULL IDENTITY,
  CategoriaId int NOT NULL,
  Titulo nvarchar(120) NOT NULL,
  Descripcion nvarchar(150) NOT NULL,
  Publicado datetime2 NOT NULL,
  Precio numeric(7,2) NOT NULL,
  ImagenURL nvarchar(200)  
);

ALTER TABLE Libro
ADD CONSTRAINT Libro_PK PRIMARY KEY (LibroId);

ALTER TABLE Libro
ADD CONSTRAINT Libro_Categoria_CategoriaId_FK FOREIGN KEY (CategoriaId)
REFERENCES Categoria(CategoriaId) ON DELETE CASCADE;

-- Tabla: Review --
CREATE TABLE Review(
  ReviewId int NOT NULL,
  LibroId int NOT NULL,
  Votante nvarchar(100) NOT NULL,
  Estrellas tinyint NOT NULL,
  Comentario nvarchar(3000) NOT NULL
);

ALTER TABLE Review
ADD CONSTRAINT Review_PK PRIMARY KEY (ReviewId);

ALTER TABLE Review
ADD CONSTRAINT Review_Libro_LibroId_FK FOREIGN KEY (LibroId)
REFERENCES Libro(LibroId) ON DELETE CASCADE;

-- Tabla: LibroPrecioOferta --
CREATE TABLE LibroPrecioOferta(
  LibroPrecioOfertaId int NOT NULL IDENTITY,
  LibroId int NOT NULL,
  NuevoPrecio numeric(7,2) NOT NULL,
  MensajePromocional nvarchar(120) NOT NULL
)

ALTER TABLE LibroPrecioOferta
ADD CONSTRAINT LibroPrecioOferta_PK PRIMARY KEY(LibroPrecioOfertaId);

ALTER TABLE LibroPrecioOferta
ADD CONSTRAINT LibroPrecioOferta_LibroId_UNQ UNIQUE (LibroId);

ALTER TABLE LibroPrecioOferta
ADD CONSTRAINT LibroPrecioOferta_Libro_LibroId_FK FOREIGN KEY(LibroId)
REFERENCES Libro(LibroId) ON DELETE CASCADE;

-- Tabla: Autor --
CREATE TABLE Autor
(
  AutorId int NOT NULL IDENTITY,
  Nombre nvarchar(120) NOT NULL,
  WebURL nvarchar(120) NOT NULL
)

ALTER TABLE Autor
ADD CONSTRAINT Autor_PK PRIMARY KEY(AutorId);

--Tabla: AutorLibro --
CREATE TABLE AutorLibro
(
  AutorLibroId int NOT NULL IDENTITY,
  AutorId int NOT NULL,
  LibroId int NOT NULL,
  Orden int NOT NULL
);

ALTER TABLE AutorLibro
ADD CONSTRAINT AutorLibro_PK PRIMARY KEY(AutorLibroId);

ALTER TABLE AutorLibro
ADD CONSTRAINT AutorLibro_AutorId_LibroId_UNQ UNIQUE(AutorId,LibroId);

ALTER TABLE AutorLibro
ADD CONSTRAINT AutorLibro_Autor_AutorId_FK FOREIGN KEY(AutorId)
REFERENCES Autor(AutorId) ON DELETE CASCADE;

ALTER TABLE AutorLibro
ADD CONSTRAINT AutorLibro_Libro_LibroId_FK FOREIGN KEY(LibroId)
REFERENCES Libro(LibroId) ON DELETE CASCADE;