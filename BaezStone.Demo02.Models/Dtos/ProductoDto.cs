using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Dtos
{
    public class ProductoDto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
    }
}