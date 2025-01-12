using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Dtos
{
    public class ProductoDto
    {
        public string FullName { get; set; }
        public string Category { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
    }
}