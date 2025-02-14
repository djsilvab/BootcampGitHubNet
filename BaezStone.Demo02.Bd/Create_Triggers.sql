CREATE TRIGGER TRG_LibroTituloEstado_AfterUpdate
ON Libro
AFTER UPDATE 
AS
  IF UPDATE(TITULO)
    INSERT INTO LibroTituloEstado(LibroId,TituloAnterior,TituloActualizado,FechaActualizado)
    SELECT i.LibroId, d.Titulo,i.Titulo,GETDATE()
    FROM inserted i
         JOIN deleted d ON i.LibroId = d.LibroId;


CREATE TRIGGER TRG_LibroHistorico_AfterDelete
ON Libro
AFTER DELETE
AS  
  INSERT INTO LibroHistorico(LibroId,Titulo,Descripcion,Publicado,Precio,ImagenURL,CategoriaId)
  SELECT LibroId, Titulo, Descripcion, Publicado, Precio, ImagenURL, CategoriaId
  FROM deleted;