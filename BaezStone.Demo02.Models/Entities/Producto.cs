using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Entities
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        [Column("ProductoId")]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Category { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
    }
}