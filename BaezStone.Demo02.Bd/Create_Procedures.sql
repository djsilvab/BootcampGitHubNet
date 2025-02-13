CREATE PROCEDURE uspObtenerLibrosPublicadosPorRango
(
  @rangoinicio INT,
  @rangofin INT
)       
AS
  SELECT a.Nombre 'Autor',
         l.Titulo 'Libro',
         l.Publicado 'Publicado',
         CASE 
              WHEN YEAR(l.publicado) < 1900 THEN 'Antiguo' 
              WHEN YEAR(l.publicado) >= 1900 THEN 'Moderno'
              ELSE 'Indeterminado'
         END 'TipoLibro'
  FROM AutorLibro al 
       INNER JOIN Autor a ON al.AutorId = a.AutorId
       INNER JOIN Libro l ON al.LibroId = l.LibroId
  WHERE YEAR(l.Publicado) >= @rangoinicio AND YEAR(l.Publicado) <= @rangofin
GO


ALTER PROCEDURE uspCambiarPrecioPorCategoria
(
  @CategoriaId INT,
  @Porcentaje NUMERIC,
  @TextoPromocional NVARCHAR(120)
)
AS
  IF (@Porcentaje<=0) OR (@Porcentaje>100)
    BEGIN
      PRINT 'El campo Porcentaje debe ser entre 1 y 100';
    END
  ELSE
    BEGIN
      -- Borrar los registros anteriores --
      DELETE FROM LibroPrecioOferta
      WHERE LibroId IN ( SELECT LibroId
                        FROM Libro
                        WHERE CategoriaId = @CategoriaId );

      -- Insertar los nuevos precios de oferta --
      INSERT INTO LibroPrecioOferta(LibroId,
                                    NuevoPrecio,
                                    MensajePromocional)
      SELECT LibroId, 
              Precio - (Precio * @Porcentaje)/100 'PrecioOferta',
              @TextoPromocional
      FROM Libro
      WHERE CategoriaId = @CategoriaId;
    END
GO