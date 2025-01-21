using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Entities
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        [Column("MarcaId")]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}