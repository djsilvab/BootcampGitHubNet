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
            new Producto(){Id = 1, Nombre = "XXX", Precio=2000, MarcaId=1,CategoriaId=2,Costo=100},
            new Producto(){Id = 2, Nombre = "YYY", Precio=3000, MarcaId=1,CategoriaId=2,Costo=200},
            new Producto(){Id = 3, Nombre = "ZZZ", Precio=3500, MarcaId=1,CategoriaId=2,Costo=150}
        };
        
    }
}