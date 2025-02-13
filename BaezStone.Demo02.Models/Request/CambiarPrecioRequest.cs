using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Request
{
    public class CambiarPrecioRequest
    {
        public int CategoriaId { get; set; }
        public decimal Porcentaje { get; set; }
        public string TextoPromocional { get; set; }
    }
}