using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaezStone.Demo02.Models.Entities;

namespace BaezStone.Demo02.Data
{
    public static class ProductoData
    {
        public static List<Producto> ListaProducto = new List<Producto>(){
            new Producto(){Id = 1, FullName = "XXX", Precio=2000},
            new Producto(){Id = 2, FullName = "YYY", Precio=3000},
            new Producto(){Id = 3, FullName = "ZZZ", Precio=3500}
        };
        
    }
}