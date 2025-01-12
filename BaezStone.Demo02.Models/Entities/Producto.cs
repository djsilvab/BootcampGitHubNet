using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Category { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
    }
}