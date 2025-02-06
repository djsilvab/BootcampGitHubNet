using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaezStone.Demo02.Models.Entities;

namespace BaezStone.Demo02.Models.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public List<LibroDto> Libros { get; set; }
    }
}