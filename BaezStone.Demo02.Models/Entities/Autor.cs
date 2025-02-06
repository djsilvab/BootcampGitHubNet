using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Entities
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        [Column("AutorId")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string WebURL { get; set; }
        public List<AutorLibro> AutoresLibros { get; set; }
    }
}