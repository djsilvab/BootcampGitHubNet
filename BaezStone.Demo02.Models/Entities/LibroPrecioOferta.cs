using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Entities
{
    [Table("LibroPrecioOferta")]
    public class LibroPrecioOferta
    {
        [Key]
        [Column("LibroPrecioOfertaId")]
        public int Id { get; set; }
        public int LibroId { get; set; }
        [ForeignKey("LibroId")]
        public Libro Libro { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal NuevoPrecio { get; set; }
        public string MensajePromocional { get; set; }
    }
}