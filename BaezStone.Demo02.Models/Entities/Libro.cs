using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Entities
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        [Column("LibroId")]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Publicado { get; set; }
        public decimal Precio { get; set; }
        public string ImagenURL { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }        
        public LibroPrecioOferta LibroPrecioOferta { get; set; }
        public List<AutorLibro> AutoresLibros { get; set; }
        public List<Review> Reviews { get; set; }
    }
}