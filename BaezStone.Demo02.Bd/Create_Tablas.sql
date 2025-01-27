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