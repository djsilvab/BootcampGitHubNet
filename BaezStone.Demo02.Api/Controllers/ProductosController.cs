using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaezStone.Demo02.Data;
using BaezStone.Demo02.Data.Context;
using BaezStone.Demo02.Models.Dtos;
using BaezStone.Demo02.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaezStone.Demo02.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetAll()
            => await context.Productos
                .Include(x => x.Categoria)
                .Include(x => x.Marca)
                .Select(x => new ProductoDto{
                                Nombre = x.Nombre,
                                Categoria = x.Categoria.Nombre,
                                Marca = x.Marca.Nombre,
                                Precio = x.Precio,
                                Costo = x.Costo
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetOne(int id)
        {
            Producto? producto = await context.Productos
                                        .Include(x => x.Categoria)
                                        .Include(x => x.Marca)
                                        .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if(producto is null) return NotFound();                                        

            var productoDto = new ProductoDto{
                Nombre = producto.Nombre,
                Categoria = producto.Categoria.Nombre,
                Marca = producto.Marca.Nombre,
                Costo = producto.Costo,
                Precio = producto.Precio
            };

            return Ok(productoDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> CreateOne(Producto productoCreate)
        {
            await context.Productos.AddAsync(productoCreate);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOne), new { id = productoCreate.Id }, productoCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOne(int id, Producto productoUpdate)
        {
            if(!id.Equals(productoUpdate.Id)) return NotFound();
            var exists = await context.Productos.AnyAsync(x => x.Id.Equals(id));
            if(!exists) return NotFound();

            context.Update(productoUpdate);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOne(int id)
        {
            var exists = await context.Productos.AnyAsync(x => x.Id == id);
            if(!exists) return NotFound();
            
            context.Productos.Remove(new Producto{ Id = id});
            await context.SaveChangesAsync();
            return NoContent();

        }
            

    }
}