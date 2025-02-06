using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaezStone.Demo02.Data.Context;
using BaezStone.Demo02.Models.Dtos;
using BaezStone.Demo02.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaezStone.Demo02.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroDto>>> GetAll()
            => await context.Libros
                            .Include(x => x.Categoria)
                            .Select(l => new LibroDto{
                                Titulo = l.Titulo,
                                Categoria = l.Categoria.Nombre,
                                Precio = l.Precio
                            })
                            .ToListAsync();

        [HttpGet("FindByTitulo")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetOneByTitulo(string titulo)
            => await context.Libros
                            .Include(x => x.Categoria)
                            //.Where(x => x.Titulo.Contains(titulo))
                            .Where(x => EF.Functions.Like(x.Titulo, $"{titulo}%"))
                            .OrderBy(x => x.Titulo)
                            .ThenByDescending(x => x.Descripcion)
                            .ToListAsync();

        [HttpGet("GetCategoryWithBooks")]
        public async Task<ActionResult<List<CategoriaDto>>> GetCategoriesWithBooks()
            =>  await context.Categorias.Select(c => new CategoriaDto{
                    Id = c.Id,
                    Categoria = c.Nombre,
                    Libros = c.Libros.Select(l => new LibroDto{ 
                        Titulo = l.Titulo,
                        Descripcion = l.Descripcion,
                        Precio = l.Precio
                     }).ToList()
                }).ToListAsync();
        
    }
}