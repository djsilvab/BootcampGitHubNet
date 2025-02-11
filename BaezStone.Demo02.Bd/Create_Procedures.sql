CREATE PROCEDURE uspObtenerLibrosPublicadosPorRango
(
  @rangoinicio INT,
  @rangofin INT
)       
AS
  SELECT a.Nombre 'Autor',
         l.Titulo 'Libro',
         l.Publicado 'Publicado'
  FROM AutorLibro al 
       INNER JOIN Autor a ON al.AutorId = a.AutorId
       INNER JOIN Libro l ON al.LibroId = l.LibroId
  WHERE YEAR(l.Publicado) >= @rangoinicio AND YEAR(l.Publicado) <= @rangofin;
GO