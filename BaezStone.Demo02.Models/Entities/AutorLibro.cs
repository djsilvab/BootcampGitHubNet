using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Entities
{
    [Table("AutorLibro")]
    public class AutorLibro
    {
        [Key]
        [Column("AutorLibro")]
        public int Id { get; set; }
        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public Autor Autor { get; set; }
        public int LibroId { get; set; }
        [ForeignKey("LibroId")]
        public Libro Libro { get; set; }
        public int Orden { get; set; }
    }
}