using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Entities
{
    [Table("Review")]
    public class Review
    {        
        [Key]
        [Column("ReviewId")]
        public int Id { get; set; }
        public int LibroId { get; set; }
        [ForeignKey("LibroId")]
        public Libro Libro { get; set; }
        public string Votante { get; set; }
        public byte Estrellas { get; set; }
        public string Comentario { get; set; }
    }
}