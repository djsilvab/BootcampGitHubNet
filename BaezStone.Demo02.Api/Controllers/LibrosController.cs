using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaezStone.Demo02.Data.Context;
using BaezStone.Demo02.Models.Dtos;
using BaezStone.Demo02.Models.Entities;
using BaezStone.Demo02.Models.Request;
using BaezStone.Demo02.Models.Usp;
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

        [HttpGet("GetBookUsingUnion")]
        public async Task<ActionResult<IEnumerable<LibroDto>>> GetBooksUsingUnionQuery()
        {
            var books1 = await context.Libros
                                      .Include(l => l.Categoria)   
                                      .Where(l => l.Precio >= 40)
                                      //.OrderBy(l => l.Titulo)
                                      .Select(l => new LibroDto{
                                        Titulo = l.Titulo,
                                        Categoria = l.Categoria.Nombre,
                                        Precio = l.Precio,
                                        Publicado = l.Publicado
                                      }).ToListAsync();

            var books2 = await context.Libros
                                      .Include(l => l.Categoria)   
                                      .Where(l => l.Publicado.Year >= 2013)
                                      //.OrderBy(l => l.Titulo)
                                      .Select(l => new LibroDto{
                                        Titulo = l.Titulo,
                                        Categoria = l.Categoria.Nombre,
                                        Precio = l.Precio,
                                        Publicado = l.Publicado
                                      }).ToListAsync();

            var lstResult = books1.Union(books2);
            //lstResult = books1.Concat(books2); //=>UNION ALL
            return Ok(lstResult);
        }

        [HttpGet("GetBooksByGroup")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetBooksByGroupCategory()
        {
            var lst = await context.Libros
                                    .Include(l => l.Categoria)                                    
                                    //.GroupBy(l => l.Categoria.Nombre)
                                    .GroupBy(l => new { l.Categoria.Nombre, l.Titulo })
                                    .Select(grp => new {
                                        Categoria = grp.Key,
                                        Cantidad = grp.Count()
                                    })
                                    .ToListAsync();
            return Ok(lst);                                    
        }

        [HttpGet("GetBooksByGroupMax")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetBooksByGroupCategoryMax()
        {
            var lst = await context.Libros
                                    .Include(l => l.Categoria)                                    
                                    .GroupBy(l => l.Categoria.Nombre)                                    
                                    .Select(grp => new {
                                        Categoria = grp.Key,
                                        PrecioMax = grp.Select(x => x.Precio).Max()
                                    })
                                    .ToListAsync();
            return Ok(lst);                                    
        }

        [HttpGet("GetBooksDetails")]
        public async Task<ActionResult<IEnumerable<LibroDetalleDto>>> GetBooksDetails()
        {            
             var lst = await context.Libros
                                    .Include(l => l.Categoria)
                                    .Include(l => l.LibroPrecioOferta)
                                    .Include(l => l.AutoresLibros)
                                    .ThenInclude(l => l.Autor)
                                    .Include(l => l.Reviews)
                                    .Select(l => new LibroDetalleDto{
                                         Titulo = l.Titulo,
                                         Categoria = l.Categoria.Nombre,
                                         Precio = l.Precio,
                                         Publicado = l.Publicado,
                                         PrecioActual = l.LibroPrecioOferta != null ? l.LibroPrecioOferta.NuevoPrecio : l.Precio,
                                         TextoPromocional = l.LibroPrecioOferta != null ? l.LibroPrecioOferta.MensajePromocional : null,
                                         Autores = string.Join(", ", l.AutoresLibros.Select(x => x.Autor.Nombre)),
                                         CantidadReviews = l.Reviews.Count(),
                                         PromedioReviews = l.Reviews.Select(x => (double?)x.Estrellas).Average()
                                    })
                                    .ToListAsync();
             return Ok(lst);                               
        }

        [HttpGet("GetRango")]
        public async Task<ActionResult<IEnumerable<LibroPublicado>>> GetRangoSP(int rangoIni, int rangoFin)
        {
            var lst = await context.LibrosPublicados
                                   .FromSqlRaw("uspObtenerLibrosPublicadosPorRango {0},{1}", rangoIni, rangoFin)
                                   .ToListAsync();
            return Ok(lst);                                   
        }

        [HttpPost("CambiarPrecioPorCategoria")]
        public async Task<ActionResult> CambiarPrecioPorCategoriaSP(CambiarPrecioRequest precioRequest)
        {
            if(precioRequest.Porcentaje <= 0 || precioRequest.Porcentaje > 0)return BadRequest("El campo Porcentaje debe ser entre 1 y 100");

            await context.Database
                    .ExecuteSqlInterpolatedAsync(
                        $"EXEC uspCambiarPrecioPorCategoria @CategoriaId={precioRequest.CategoriaId},@Porcentaje={precioRequest.Porcentaje},@TextoPromocional={precioRequest.TextoPromocional}"
                    );
            
            return Ok("Actualización de precio");                        
        }


    }
}