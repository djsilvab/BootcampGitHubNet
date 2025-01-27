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
                .Include(x => x.Promocion)
                .Select(x => new ProductoDto{
                                Nombre = x.Nombre,
                                Categoria = x.Categoria.Nombre,
                                Marca = x.Marca.Nombre,
                                Precio = x.Precio,
                                Costo = x.Costo,
                                PrecioActual = x.Promocion != null? 
                                               x.Promocion.NuevoPrecio : x.Precio,
                                TextoPromocional = x.Promocion != null? 
                                                   x.Promocion.TextoPromocional :
                                                   string.Empty
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetOne(int id)
        {
            Producto? productoBD = await context.Productos
                                        .Include(x => x.Categoria)
                                        .Include(x => x.Marca)
                                        .Include(x => x.Promocion)
                                        .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if(productoBD is null) return NotFound();                                        

            var productoDto = new ProductoDto{
                Nombre = productoBD.Nombre,
                Categoria = productoBD.Categoria.Nombre,
                Marca = productoBD.Marca.Nombre,
                Costo = productoBD.Costo,
                Precio = productoBD.Precio,
                PrecioActual = productoBD.Promocion != null? 
                               productoBD.Promocion.NuevoPrecio : productoBD.Precio,
                                TextoPromocional = productoBD.Promocion != null? 
                                                   productoBD.Promocion.TextoPromocional :
                                                   string.Empty
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