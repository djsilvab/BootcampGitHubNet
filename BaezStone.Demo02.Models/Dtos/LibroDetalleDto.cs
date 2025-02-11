using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaezStone.Demo02.Models.Dtos
{
    public class LibroDetalleDto
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public DateTime Publicado { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioActual { get; set; }
        public string TextoPromocional { get; set; }
        public string Autores { get; set; }
        public int CantidadReviews { get; set; }
        public double? PromedioReviews { get; set; }        
    }
}