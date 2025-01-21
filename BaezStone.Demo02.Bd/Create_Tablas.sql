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

-- Data: Categoria --
INSERT INTO Categoria(Nombre) Values('Computadoras'),('Impresoras');

-- Data: Marca --
INSERT INTO Marca(Nombre) Values('HP'),('Apple');